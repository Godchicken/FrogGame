using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HappyJumpingFrog
{
    // [เจ้าของ: กูเอง] หน้าเล่นเกม = "ตัวรวมทุกส่วน"
    //
    // ลูปเกม (timer1_Tick ทุก 30 ms):
    //   1. นับเวลา
    //   2. ให้ทุกวัตถุขยับ (Update) แล้วเช็คว่าชนกบไหม → เรียก OnHit
    //   3. เช็คตกน้ำ / ออกนอกจอ / หมดเวลา → กบตาย
    //   4. อัปเดตตัวเลขด้านข้าง แล้ววาดใหม่
    //   5. เช็คจบเกม (ชีวิตหมด) หรือผ่านด่าน (ดอกบัวหมด)
    public partial class FormGame : Form
    {
        private readonly GameController controller = new GameController();
        private readonly PlayerFrog frog = new PlayerFrog(400, 500);
        private JumpingField field;
        private GameTimer gameTimer;
        

        public FormGame()
        {
            InitializeComponent();
            DoubleBuffered = true;     // กันภาพกะพริบ
            KeyPreview = true;         // ให้ฟอร์มรับปุ่มก่อนคอนโทรลอื่น
            KeyDown += FormGame_KeyDown;
            Paint += FormGame_Paint;

            field = controller.CreateField();
            gameTimer = new GameTimer(controller.TimeLimit);
            UpdateLabels();
            timer1.Start();

            SoundManager.PlayMusic();
            FormClosed += (s, e) => SoundManager.StopMusic();
        }

        // ---------- รับปุ่ม ----------
        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (!timer1.Enabled) return;   // หยุดอยู่ (Pause/เปิดหน้าต่างอื่น) ไม่รับปุ่ม

            bool moved = true;

            switch (e.KeyCode)
            {
                case Keys.W: case Keys.Up:    frog.Move(0, -1); break;
                case Keys.S: case Keys.Down:  frog.Move(0, 1);  break;
                case Keys.A: case Keys.Left:  frog.Move(-1, 0); break;
                case Keys.D: case Keys.Right: frog.Move(1, 0);  break;
                default: moved = false; break;
            }
            if (moved) SoundManager.Play(Sfx.Jump);
            Invalidate();
        }

        // ---------- วาด ----------
        private void FormGame_Paint(object sender, PaintEventArgs e)
        {
            field.Draw(e.Graphics);   // สนามก่อน
            frog.Draw(e.Graphics);    // กบวาดทีหลังสุด จะได้อยู่บนสุด
        }

        // ---------- ลูปเกม ----------
        private void timer1_Tick(object sender, EventArgs e)
        {
            gameTimer.Tick(timer1.Interval);
            frog.OnLog = false;   // เช็คใหม่ทุก tick: ถ้ามีซุงอยู่ใต้เท้า ซุงจะตั้งเป็น true ให้เอง

            foreach (GameObject obj in field.Items)
            {
                obj.Update();
                if (!obj.Intersects(frog)) continue;

                obj.OnHit(frog);       // ผลลัพธ์ขึ้นกับว่า obj เป็นชนิดไหน (polymorphism)
                GiveReward(obj);       // คะแนน/ชีวิต/เวลา ให้ที่นี่ที่เดียว
            }

            field.UpdateSpawn();

            if (frog.IsOutOfBounds(ClientSize.Width - panelSide.Width, ClientSize.Height))
            {
                frog.Die();
            }

            if (field.Water.Intersects(frog) && !frog.OnLog)
            {
                frog.Die();           // อยู่ในน้ำแต่ไม่ได้อยู่บนซุง = จมน้ำ
                if (frog.Lives > 0) SoundManager.Play(Sfx.Splash);
            }

            if (gameTimer.IsTimeUp)
            {
                frog.Die();
                gameTimer.Reset(controller.TimeLimit);
            }

            UpdateLabels();
            Refresh();                // วาดทันที (เผื่อกำลังจะเปิดหน้าต่างทับ)

            int lotusLeft = field.Items.OfType<TargetLotus>().Count(l => l.IsActive);

            if (frog.Lives <= 0)
            {
                ShowGameOver();
            }
            else if (lotusLeft == 0)
            {
                AdvanceLevel();
            }
        }

        private void GiveReward(GameObject obj)
        {
            if (obj is TargetLotus)
            {
                frog.AddScore(controller.CalculateScore(gameTimer.ElapsedSecond));
                gameTimer.ResetElapsed();
            }
            else if (obj is Item)
            {
                Item pickup = (Item)obj;
                if (pickup.Type == ItemType.Heart)
                {
                    frog.AddLife();
                    SoundManager.Play(Sfx.Heal);
                }
                else
                {
                    gameTimer.AddSeconds(30);
                    SoundManager.Play(Sfx.Time);
                }
            }
        }

        private void UpdateLabels()
        {
            int total = gameTimer.SecondsLeft;
            labelTime.Text = string.Format("{0:D2}:{1:D2}", total / 60, total % 60);
            labelLevel.Text = controller.LevelText();
            labelScore.Text = frog.Score.ToString();
            labelLives.Text = frog.Lives + " / " + PlayerFrog.MaxLives;
        }

        // ---------- จบเกม / ผ่านด่าน ----------
        private void ShowGameOver()
        {
            timer1.Stop();
            SoundManager.StopMusic();
            SoundManager.Play(Sfx.GameOver);
            using (FormGameOver dlg = new FormGameOver())
            {
                dlg.FinalScore = frog.Score;
                DialogResult result = dlg.ShowDialog(this);

                if (result == DialogResult.Retry) ResetGame();
                else if (result == DialogResult.OK) SubmitScore();
                else Close();
            }
        }

        private void AdvanceLevel()
        {
            timer1.Stop();
            int oldMain = controller.MainLevel;

            if (controller.NextLevel())
            {
                SoundManager.Play(Sfx.NextLevel);
                if (controller.MainLevel != oldMain)
                {
                    gameTimer.Reset(controller.TimeLimit);   // ขึ้นด่านหลักใหม่ = เวลาใหม่
                }
                gameTimer.ResetElapsed();
                frog.ResetPosition();
                field = controller.CreateField();
                timer1.Start();
            }
            else
            {
                SoundManager.StopMusic();
                SoundManager.Play(Sfx.Win);
                using (FormCongratulations dlg = new FormCongratulations())
                {
                    dlg.FinalScore = frog.Score;
                    DialogResult result = dlg.ShowDialog(this);

                    if (result == DialogResult.Retry) ResetGame();
                    else if (result == DialogResult.OK) SubmitScore();
                    else Close();
                }
            }
        }

        private void ResetGame()
        {
            frog.Reset();
            controller.ResetLevel();
            gameTimer.Reset(controller.TimeLimit);
            gameTimer.ResetElapsed();
            field = controller.CreateField();
            UpdateLabels();
            timer1.Start();
            SoundManager.PlayMusic();
        }

        private void SubmitScore()
        {
            using (FormName nameForm = new FormName())
            {
                if (nameForm.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        HighScoreManager.Add(nameForm.PlayerName, frog.Score);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            Close();   // กลับไปหน้าเมนู
        }

        // ---------- ปุ่ม Pause ----------
        private void buttonPause_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            SoundManager.PauseMusic();   // พักเพลงระหว่าง Pause

            using (PauseDialog dlg = new PauseDialog())
            {
                dlg.SoundOn = SoundManager.SoundEnabled;
                dlg.MusicOn = SoundManager.MusicEnabled;
                DialogResult result = dlg.ShowDialog(this);
                SoundManager.SoundEnabled = dlg.SoundOn;
                SoundManager.MusicEnabled = dlg.MusicOn;

                if (result == DialogResult.Abort) Close();   // กลับเมนู
                else
                {
                    timer1.Start();
                    SoundManager.PlayMusic();   // เล่นเพลงต่อ (ถ้าผู้เล่นไม่ได้ปิดเพลง)
                }
            }
            ActiveControl = null;   // คืนโฟกัสให้ฟอร์ม จะได้รับปุ่ม WASD ต่อ
        }
    }
}
