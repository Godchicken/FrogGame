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

        private readonly int[] roadLanes = { 3, 4, 4 };
        private readonly int[] waterLanes = { 3, 3, 4 };
        private readonly int[] speeds = { 1, 2, 3 };
        private readonly int[] times = { 1500, 1200, 900 };

        //  2: อ่านจากตารางตาม MainLevel
        public int TimeLimit
        {
            get { return times[MainLevel - 1]; }
        }

//  3: จำนวนดอกบัวตามด่านย่อย  SubLevel 1→5 ดอก, 2→4, 3→3, 4→2, 5→1
        private int GetLotusCount()
        {
            return 6 - SubLevel;
        }

        //  4: คะแนนตามเวลาที่ใช้ต่อดอกบัว
        //   ใช้ไม่เกิน 10 วิ → 100,  ไม่เกิน 30 วิ → 70,  มากกว่านั้น → 40
        public int CalculateScore(int secondsUsed)
        {
            if (secondsUsed <= 10) return 100;
            if (secondsUsed <= 30) return 70;

            return 40; // มากกว่า 30 วินาที
        }
        //  5: เลื่อนด่าน
        //   ถ้าเป็นด่านสุดท้ายแล้ว (MainLevel 3 และ SubLevel 5) → return false (ไม่มีด่านต่อ = ชนะเกม)
        //   ไม่งั้น SubLevel++ ; ถ้าเกิน 5 → SubLevel = 1, MainLevel++ ; return true
        // (ตอนนี้ return false เพื่อให้เห็นหน้า "ชนะ" ตอนเทสต์)
        public bool NextLevel()
        {
            // ถ้าเป็นด่านสุดท้ายแล้ว (ด่าน 3-5) ไม่มีด่านต่อ คืนค่า false (ชนะเกม)
            if (MainLevel == 3 && SubLevel == 5)
            {
                return false;
            }

            SubLevel++; // เลื่อนด่านย่อย

            // ถ้าด่านย่อยเกิน 5 ให้กลับไป 1 แล้วเพิ่มด่านหลัก
            if (SubLevel > 5)
            {
                SubLevel = 1;
                MainLevel++;
            }

            return true;
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
            int road = roadLanes[MainLevel - 1];
            int water = waterLanes[MainLevel - 1];
            int speed = speeds[MainLevel - 1];
            int lotus = GetLotusCount();

            return new JumpingField(road, water, speed, lotus);
        }

        public string LevelText()
        {
            return MainLevel + " - " + SubLevel;
        }
    }
}
