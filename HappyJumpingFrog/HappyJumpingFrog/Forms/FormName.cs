using System;
using System.Windows.Forms;

namespace HappyJumpingFrog
{
    // [เจ้าของ: ซีน] หน้าใส่ชื่อก่อนบันทึกคะแนน
    // สัญญากับ FormGame: อ่านชื่อจาก PlayerName หลังได้ DialogResult.OK
    // กติกาที่ต้องมี: ห้ามว่าง และห้ามมีเครื่องหมาย ',' (ไฟล์คะแนนใช้ ',' คั่นข้อมูล)
    public partial class FormName : Form
    {
        public string PlayerName
        {
            get { return textName.Text.Trim(); }
        }

        public FormName()
        {
            InitializeComponent();
            textName.MaxLength = 15;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (PlayerName.Length == 0)
            {
                MessageBox.Show("Please enter your name!", "Name required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (PlayerName.Contains(","))
            {
                MessageBox.Show("Please don't use ',' in the name.", "Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textName.Clear();
            }
            else
            {
                DialogResult = DialogResult.OK;   // จำกัดความยาวชื่อให้ด้วย ไม่เกิน 15 ตัว
            }
        }
    }
}
