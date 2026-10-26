using System;
using System.Drawing;
using System.Windows.Forms;

namespace HappyJumpingFrog
{
    // [เจ้าของ: ซีน] หน้าเมนูหลัก
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();

            SetupHover(buttonPlay, 13.18f, 14f);
            SetupHover(buttonHighScore, 13.18f, 14f);
            SetupHover(buttonExit, 13.18f, 14f);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            using (FormGame game = new FormGame())
            {
                Hide();
                game.ShowDialog();
                Show();
            }
        }

        private void buttonHighScore_Click(object sender, EventArgs e)
        {
            using (FormHighScore form = new FormHighScore())
            {
                Hide();
                form.ShowDialog();
                Show();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetupHover(Button btn, float normalSize, float hoverSize)
        {
            string fontName = btn.Font.FontFamily.Name;
            FontStyle style = btn.Font.Style;

            btn.MouseEnter += (s, e) =>
                btn.Font = new Font(fontName, hoverSize, style);

            btn.MouseLeave += (s, e) =>
                btn.Font = new Font(fontName, normalSize, style);
        }

        private void SetupSmoothHover(Button btn, float normalSize, float hoverSize)
        {
            float current = normalSize;
            float target = normalSize;
            string fontName = btn.Font.FontFamily.Name;
            FontStyle style = btn.Font.Style;

            var timer = new Timer { Interval = 15 };
            timer.Tick += (s, e) =>
            {
                if (Math.Abs(current - target) < 0.3f)
                {
                    current = target;
                    timer.Stop();
                }
                else
                {
                    current += (target - current) * 0.25f;
                }
                btn.Font = new Font(fontName, current, style);
            };

            btn.MouseEnter += (s, e) => { target = hoverSize; timer.Start(); };
            btn.MouseLeave += (s, e) => { target = normalSize; timer.Start(); };
        }
    }
}
