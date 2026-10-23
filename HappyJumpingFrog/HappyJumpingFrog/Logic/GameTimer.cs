using System;
namespace HappyJumpingFrog
{
    // [เจ้าของ: โอ๊ต] ตัวนับเวลาถอยหลังของด่าน + เวลาที่ใช้ไปต่อดอกบัว
    public class GameTimer
    {
        // เก็บเวลาเป็นมิลลิวินาที 2 ตัว timeLeftMs (เหลือ) และ elapsedMs (ใช้ไป)
        private int timeLeftMs;
        private int elapsedMs;

        public GameTimer(int second)
        {
            timeLeftMs = second * 1000;
            elapsedMs = 0;
        }

        // เวลาที่เหลือ (วินาที, ปัดขึ้น) : ใช้ Math.Ceiling(timeLeftMs / 1000.0)
        public int SecondsLeft
        {
            get { return (int)Math.Ceiling(timeLeftMs / 1000.0); }
        }

        // เวลาที่ใช้ไปตั้งแต่ ResetElapsed ล่าสุด (วินาที)
        // (หาร 1000 ตรงๆ เพื่อปัดเศษทิ้ง เอาแค่จำนวนวินาทีเต็มๆ ที่ผ่านไป)
        public int ElapsedSecond
        {
            get { return elapsedMs / 1000; }
        }

        // หมดเวลาหรือยัง
        public bool IsTimeUp
        {
            get { return timeLeftMs <= 0; }
        }

        // FormGame เรียกทุก tick พร้อมจำนวนมิลลิวินาทีที่ผ่านไป
        public void Tick(int ms)
        {
            timeLeftMs -= ms;
            elapsedMs += ms;

            // ถ้า timeLeftMs < 0 ให้เป็น 0
            if (timeLeftMs < 0)
            {
                timeLeftMs = 0;
            }
        }

        // ตั้งเวลาใหม่ (เริ่มด่านใหม่/ตายเพราะหมดเวลา)
        public void Reset(int second)
        {
            timeLeftMs = second * 1000;
            elapsedMs = 0;
        }

        public void ResetElapsed()
        {
            elapsedMs = 0;
        }

        // เก็บไอเท็มเวลา
        public void AddSeconds(int s)
        {
            timeLeftMs += (s * 1000);
        }
    }
}