namespace HappyJumpingFrog
{
    // [เจ้าของ: โอ๊ต] ตัวนับเวลาถอยหลังของด่าน + เวลาที่ใช้ไปต่อดอกบัว
    // ตอนนี้เป็น โครงเวลาไม่ลด เพื่อให้เกมรันได้ แก้นำเด้อ
    public class GameTimer
    {
        //  เก็บเวลาเป็นมิลลิวินาที 2 ตัว  timeLeftMs (เหลือ) และ elapsedMs (ใช้ไป)
        private int seconds;

        public GameTimer(int second)
        {
            seconds = second;
        }

        // เวลาที่เหลือ (วินาที, ปัดขึ้น)           : ใช้ Math.Ceiling(timeLeftMs / 1000.0)
        public int SecondsLeft { get { return seconds; } }

        // เวลาที่ใช้ไปตั้งแต่ ResetElapsed ล่าสุด (วินาที)
        public int ElapsedSecond { get { return 0; } }

        // หมดเวลาหรือยัง
        public bool IsTimeUp { get { return false; } }

        // FormGame เรียกทุก tick พร้อมจำนวนมิลลิวินาทีที่ผ่านไป
        // TODO(C): timeLeftMs -= ms ; elapsedMs += ms ; ถ้า timeLeftMs < 0 ให้เป็น 0
        public void Tick(int ms) { }

        // ตั้งเวลาใหม่ (เริ่มด่านใหม่/ตายเพราะหมดเวลา)
        public void Reset(int second) { seconds = second; }

        public void ResetElapsed() { }

        // เก็บไอเท็มเวลา
        public void AddSeconds(int s) { }
    }
}
