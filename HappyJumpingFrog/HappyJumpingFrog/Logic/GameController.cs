namespace HappyJumpingFrog
{
    // [เจ้าของ: โอ๊ต] ผู้คุมกติกา: รู้ว่าอยู่ด่านไหน เวลาเท่าไร คิดคะแนน เลื่อนด่าน สร้างสนาม
    // ตอนนี้เป็นค่า "ชั่วคราว" เพื่อให้เกมรันได้ แก้ตามที่จารสั่งด้วย
    public class GameController
    {
        //  1: ตารางค่าของแต่ละด่านหลัก (3 ด่านหลัก, ด่านย่อยด่านละ 5)
        //   จำนวนเลนถนน   {3, 4, 4}
        //   จำนวนเลนน้ำ    {3, 3, 4}
        //   ความเร็ว        {1, 2, 3}
        //   เวลา (วินาที)   {1500, 1200, 900}     

        public int MainLevel { get; private set; } = 1;   // 1..3
        public int SubLevel { get; private set; } = 1;    // 1..5

        //  2: อ่านจากตารางตาม MainLevel
        public int TimeLimit { get { return 60; } }

        //  3: จำนวนดอกบัวตามด่านย่อย  SubLevel 1→5 ดอก, 2→4, 3→3, 4→2, 5→1

        //  4: คะแนนตามเวลาที่ใช้ต่อดอกบัว
        //   ใช้ไม่เกิน 10 วิ → 100,  ไม่เกิน 30 วิ → 70,  มากกว่านั้น → 40
        public int CalculateScore(int secondsUsed)
        {
            return 100;
        }

        //  5: เลื่อนด่าน
        //   ถ้าเป็นด่านสุดท้ายแล้ว (MainLevel 3 และ SubLevel 5) → return false (ไม่มีด่านต่อ = ชนะเกม)
        //   ไม่งั้น SubLevel++ ; ถ้าเกิน 5 → SubLevel = 1, MainLevel++ ; return true
        // (ตอนนี้ return false เพื่อให้เห็นหน้า "ชนะ" ตอนเทสต์)
        public bool NextLevel()
        {
            return false;
        }

        public void ResetLevel()
        {
            MainLevel = 1;
            SubLevel = 1;
        }

        //  6: สร้างสนามตามตาราง
        //   return new JumpingField(เลนถนน, เลนน้ำ, ความเร็ว, จำนวนดอกบัว);
        public JumpingField CreateField()
        {
            return new JumpingField(3, 3, 1, 3);
        }

        public string LevelText()
        {
            return MainLevel + " - " + SubLevel;
        }
    }
}
