using System.Windows.Forms;

namespace HappyJumpingFrog
{
    // [เจ้าของ: ซีน] หน้า Game Over
    // สัญญากับ FormGame: ตั้ง FinalScore ก่อน ShowDialog
    //   ปุ่ม Try Again → DialogResult.Retry   |   ปุ่ม Submit Score → DialogResult.OK
    // (ตั้งค่า DialogResult ที่ปุ่มใน Designer ไว้แล้ว)
    public partial class FormGameOver : Form
    {
        public int FinalScore
        {
            set { labelFinalScore.Text = value.ToString(); }
        }

        public FormGameOver()
        {
            InitializeComponent();
        }
    }
}
