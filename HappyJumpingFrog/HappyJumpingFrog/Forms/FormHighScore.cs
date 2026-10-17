using System;
using System.Windows.Forms;

namespace HappyJumpingFrog
{
    // [เจ้าของ: ซีน] ตารางคะแนน 5 อันดับ  (ข้อมูลมาจาก HighScoreManager.Load() ของ โอ๊ต)
    public partial class FormHighScore : Form
    {
        public FormHighScore()
        {
            InitializeComponent();
        }

        private void FormHighScore_Load(object sender, EventArgs e)
        {
            // จัดรูปแบบให้สวย เช่น "1. Mint    340"  และถ้าไม่มีข้อมูลให้แสดงข้อความ "No scores yet"
            int rank = 1;
            foreach (ScoreEntry entry in HighScoreManager.Load())
            {
                listBoxScores.Items.Add(rank + ".  " + entry.Name + "   " + entry.Score);
                rank++;
            }
        }
    }
}
