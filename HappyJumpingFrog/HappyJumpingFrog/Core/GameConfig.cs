using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyJumpingFrog
{
    // ค่าขนาดของเกม
    public static class GameConfig
    {
        public const int Cell = 50;                       // ขนาด 1 ช่อง = ขนาดกบ = ความสูง 1 เลน
        public const int Cols = 20;                       // ช่องแนวนอน
        public const int Rows = 12;                       // ช่องแนวตั้ง
        public const int FieldWidth = Cols * Cell;        // 1000
        public const int FieldHeight = Rows * Cell;       // 600
        public const int BaseY = FieldHeight - 2 * Cell;  // y ของเลนถนนล่างสุด (500)
        public const int PanelWidth = 200;                // แผงข้อมูลด้านขวา

        // ขนาดที่ตั้งไว้ตอนช่องละ 40 พิกเซล แปลงให้เข้ากับ Cell ปัจจุบัน
        public static int Scale(int sizeAt40)
        {
            return sizeAt40 * Cell / 40;
        }
    }
}
