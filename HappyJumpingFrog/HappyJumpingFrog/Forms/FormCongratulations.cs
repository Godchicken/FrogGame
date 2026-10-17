using System.Windows.Forms;

namespace HappyJumpingFrog
{
    // [เจ้าของ: ซีน] หน้าชนะเกม (ผ่านครบทุกด่าน) ควย
    // สัญญากับ FormGame: ตั้ง FinalScore ก่อน ShowDialog
    //   ปุ่ม Play Again → DialogResult.Retry   |   ปุ่ม Submit Score → DialogResult.OK
    public partial class FormCongratulations : Form
    {
        public int FinalScore
        {
            set { labelFinalScore.Text = value.ToString(); }
        }

        public FormCongratulations()
        {
            InitializeComponent();
        }

        private void buttonPlayAgain_Click(object sender, System.EventArgs e)
        {

        }
    }
}
