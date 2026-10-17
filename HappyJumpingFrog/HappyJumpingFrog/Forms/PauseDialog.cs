using System;
using System.Windows.Forms;

namespace HappyJumpingFrog
{
    // [เจ้าของ: ซีน] หน้าต่างหยุดเกม
    // สัญญากับ FormGame: SoundOn / MusicOn (รับเข้า-ส่งกลับ)
    //   ปุ่ม Continue → DialogResult.OK     (เล่นต่อ)
    //   ปุ่ม Back to Menu → DialogResult.Abort (กลับเมนู)
    // สองปุ่มนี้ตั้งค่า DialogResult ไว้ใน Designer (Properties → DialogResult) จึงไม่ต้องมี Click handler
    public partial class PauseDialog : Form
    {
        public bool SoundOn { get; set; }
        public bool MusicOn { get; set; }

        public PauseDialog()
        {
            InitializeComponent();
        }

        private void UpdateButtons()
        {
            buttonSound.Text = SoundOn ? "Sound: On" : "Sound: Off";
            buttonMusic.Text = MusicOn ? "Music: On" : "Music: Off";
        }

        private void buttonSound_Click(object sender, EventArgs e)
        {
            SoundOn = !SoundOn;
            UpdateButtons();
        }

        private void buttonMusic_Click(object sender, EventArgs e)
        {
            MusicOn = !MusicOn;
            UpdateButtons();
        }

        private void PauseDialog_Load(object sender, EventArgs e)
        {
            UpdateButtons();
        }
    }
}
