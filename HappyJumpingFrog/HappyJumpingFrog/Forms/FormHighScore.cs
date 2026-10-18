using System;
using System.Drawing;
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
            listBoxScores.Items.Clear();
            listBoxScores.Font = new Font("Consolas", 12);   // monospace เพื่อให้คอลัมน์ตรงกัน

            int rank = 0;
            foreach (ScoreEntry entry in HighScoreManager.Load())
            {
                rank++;
                if (rank > 5) break;
                // แสดงแค่ 5 อันดับ
                // {0,2}  = อันดับ ชิดขวา 2 ช่อง
                // {1,-15} = ชื่อ ชิดซ้าย 15 ช่อง (ตรงกับความยาวชื่อสูงสุดใน FormName)
                // {2,6}  = คะแนน ชิดขวา 6 ช่อง

                listBoxScores.Items.Add(
                    string.Format("{0,2}.  {1,-15}  {2,6}", rank, entry.Name, entry.Score));
            }

            if (rank == 0)
            {
                listBoxScores.Items.Add("No scores yet");
            }
        }
    }
    }
