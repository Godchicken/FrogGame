using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HappyJumpingFrog
{
    // [เจ้าของ: โอ๊ต] อ่าน/เขียนไฟล์ Highscore.txt เก็บ 5 อันดับสูงสุด
    // ตอนนี้เป็น โครง เพื่อให้เกมรันได้ แก้ให้ด้วย
    //
    // รูปแบบไฟล์: 1 บรรทัดต่อ 1 คน  "ชื่อ,คะแนน"   เช่น  Mint,340
    // (ฟอร์มใส่ชื่อของ D ต้องไม่ยอมให้ชื่อมีเครื่องหมาย ',' เพราะใช้คั่นข้อมูล)
    public static class HighScoreManager
    {
        //  เส้นทางไฟล์ = Path.Combine(Application.StartupPath, "Highscore.txt")
        private static string FilePath => Path.Combine(Application.StartupPath, "Highscore.txt");
        //  อ่านไฟล์ → รายการ ScoreEntry
        //   ถ้าไม่มีไฟล์ → คืนลิสต์ว่าง
        //   แต่ละบรรทัด: Split(',') ต้องได้ 2 ท่อน และท่อนที่ 2 แปลงเป็นเลขได้ ไม่งั้นข้ามบรรทัดนั้น
        public static List<ScoreEntry> Load()
        {
            var scores = new List<ScoreEntry>();

            // ถ้าไม่มีไฟล์ -> คืนลิสต์ว่าง
            if (!File.Exists(FilePath))
            {
                return scores;
            }

            // อ่านแต่ละบรรทัด
            string[] lines = File.ReadAllLines(FilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                // Split(',') ต้องได้ 2 ท่อน และท่อนที่ 2 แปลงเป็นเลขได้ ไม่งั้นข้าม
                if (parts.Length == 2 && int.TryParse(parts[1], out int score))
                {
                    scores.Add(new ScoreEntry(parts[0], score));
                }
            }
            return scores.OrderByDescending(s => s.Score).ToList();
        }
        

        //  โหลด → เพิ่มคนใหม่ → เรียงคะแนนมากไปน้อย → เก็บแค่ 5 อันดับ → เขียนกลับไฟล์
        //   (อาจ throw IOException / UnauthorizedAccessException — FormGame ของ A จับไว้แล้ว)
        public static void Add(string name, int score)
        {
            // 1. โหลดข้อมูลเดิมมาก่อน
            var scores = Load();

            string safeName = name.Replace(",", "").Trim();
            if (string.IsNullOrEmpty(safeName))
            {
                safeName = "Player";
            }

            // 2. เพิ่มคนใหม่เข้าไป
            scores.Add(new ScoreEntry(safeName, score));

            // 3. เรียงคะแนนมากไปน้อย -> 4. เก็บแค่ 5 อันดับ
            var top5 = scores.OrderByDescending(s => s.Score).Take(5).ToList();

            // 5. เขียนกลับลงไฟล์
            // (Exception ต่างๆ จะถูกโยนออกไปให้ FormGame ของ A จับตามที่คอมเมนต์ไว้)
            var linesToWrite = top5.Select(s => $"{s.Name},{s.Score}");
            File.WriteAllLines(FilePath, linesToWrite);
        }
    }
}
