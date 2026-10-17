using System;
using System.Windows.Forms;

namespace HappyJumpingFrog
{
    // [เจ้าของ: ซีน] หน้าเมนูหลัก
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
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
    }
}
