using System.Collections.Generic;

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

        //  อ่านไฟล์ → รายการ ScoreEntry
        //   ถ้าไม่มีไฟล์ → คืนลิสต์ว่าง
        //   แต่ละบรรทัด: Split(',') ต้องได้ 2 ท่อน และท่อนที่ 2 แปลงเป็นเลขได้ ไม่งั้นข้ามบรรทัดนั้น
        public static List<ScoreEntry> Load()
        {
            return new List<ScoreEntry>();
        }

        //  โหลด → เพิ่มคนใหม่ → เรียงคะแนนมากไปน้อย → เก็บแค่ 5 อันดับ → เขียนกลับไฟล์
        //   (อาจ throw IOException / UnauthorizedAccessException — FormGame ของ A จับไว้แล้ว)
        public static void Add(string name, int score)
        {
        }
    }
}
