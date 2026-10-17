using System;
using System.Collections.Generic;
using System.Drawing;

namespace HappyJumpingFrog
{
    // [เจ้าของ: หลุยส์] "สนาม" ของ 1 ด่าน เก็บวัตถุทั้งหมดที่อยู่ในด่านนั้น
    //
    // แผนผังแถว (แต่ละแถวสูง 40 พิกเซล) ตัวอย่างถนน 3 เลน แม่น้ำ 3 เลน:
    //
    //   y = 100  แถวดอกบัว (อยู่ในกรอบแม่น้ำ)
    //   y = 140  แม่น้ำเลนที่ 3
    //   y = 180  แม่น้ำเลนที่ 2
    //   y = 220  แม่น้ำเลนที่ 1 (ล่างสุด)
    //   y = 260  พื้นหญ้ากลาง
    //   y = 300  ถนนเลนที่ 3
    //   y = 340  ถนนเลนที่ 2
    //   y = 380  ถนนเลนที่ 1 (ล่างสุด)
    //   y = 420+ พื้นหญ้าจุดเริ่มต้น (กบเริ่มที่ y = 500)
    //
    public class JumpingField
    {
        public const int FieldWidth = 985;
        public const int Cell = 40;

        public List<GameObject> Items { get; private set; } = new List<GameObject>();
        public River Water { get; private set; }
        public Road Road { get; private set; }

        private static readonly Random rnd = new Random();
        private readonly int roadLanes;
        private readonly int riverLanes;
        private readonly int levelSpeed;
        private int spawnTicks;

        public JumpingField(int roadLanes, int riverLanes, int levelSpeed, int lotusCount)
        {
            this.roadLanes = roadLanes;
            this.riverLanes = riverLanes;
            this.levelSpeed = levelSpeed;

            // y ของแถวดอกบัว = ไต่ขึ้นจาก 340 ทีละ 40 ผ่านเลนถนนและเลนแม่น้ำทั้งหมด
            int lotusY = 340 - Cell * (roadLanes + riverLanes);

            // น้ำ: เริ่มที่แถวบัว สูงครอบเลนแม่น้ำ + แถวบัว
            Water = new River(0, lotusY, FieldWidth, Cell * (riverLanes + 1));

            // ถนน: y คือเลนบนสุดของถนน
            Road = new Road(0, 380 - Cell * (roadLanes - 1), FieldWidth, Cell * roadLanes);

            // ----------------------------------------------------------------
            //  1: สร้างศัตรูเลนถนน   (ใช้ Enemy1 / Enemy2 ที่คุณเขียนเอง)
            //
            //   for i = 0 .. roadLanes-1:            // i = 0 คือเลนล่างสุด
            //       y = 380 - 40 * i
            //       ถ้า i เป็นเลขคู่:  วิ่งซ้าย  speed = levelSpeed * -1 * 5 → Items.Add(new Enemy1(...))
            //       ถ้า i เป็นเลขคี่:  วิ่งขวา  speed = levelSpeed * +1 * 5 → Items.Add(new Enemy2(...))
            //       (x เริ่มต้นกระจายให้ไม่ซ้อนกัน เช่น FieldWidth / (roadLanes+1) * (i+1))
            //
            //  2: สร้างซุงเลนแม่น้ำ   (ใช้ Friend1 / Friend2)
            //
            //   for i = 0 .. riverLanes-1:           // i = 0 คือเลนแม่น้ำล่างสุด
            //       y = 340 - 40 * roadLanes - 40 * i
            //       สลับทิศทางซ้าย/ขวา เหมือนเลนถนน
            // ----------------------------------------------------------------

            // ดอกบัวเป้าหมาย: แบ่งความกว้างเป็น (จำนวนบัว + 1) ช่อง วางที่รอยต่อ
            for (int i = 0; i < lotusCount; i++)
            {
                Items.Add(new TargetLotus(FieldWidth / (lotusCount + 1) * (i + 1), lotusY));
            }

            spawnTicks = rnd.Next(333, 667);
        }

        // ลำดับวาด: น้ำ -> ถนน -> วัตถุทั้งหมด (กบวาดทีหลังที่ FormGame)
        public void Draw(Graphics g)
        {
            Water.Draw(g);
            Road.Draw(g);
            foreach (GameObject item in Items)
            {
                item.Draw(g);
            }
        }

        // FormGame เรียกทุก tick
        public void UpdateSpawn()
        {
            //  3: สุ่มเกิดไอเท็ม (Item ของ C) บนถนน
            //
            //   spawnTicks -= 1
            //   ถ้า spawnTicks <= 0:
            //       เลือกเลนถนนแบบสุ่ม → y = 380 - 40 * lane + 5
            //       x สุ่ม 0 .. 955
            //       ชนิดสุ่ม Heart หรือ Time → Items.Add(new Item(x, y, type))
            //       spawnTicks = สุ่ม 333 .. 667
        }
    }
}
