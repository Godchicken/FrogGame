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
        public const int FieldWidth = GameConfig.FieldWidth;
        public const int Cell = GameConfig.Cell;
        public const int BaseY = GameConfig.BaseY;
        public const int FieldHeight = GameConfig.FieldHeight;

        public List<GameObject> Items { get; private set; } = new List<GameObject>();
        public River Water { get; private set; }
        public Road Road { get; private set; }

        private static readonly Random rnd = new Random();
        private readonly int roadLanes;
        private readonly int riverLanes;
        private readonly int levelSpeed;
        private int spawnTicks;
        private static readonly Image BgLevel1 = Properties.Resources.bg_level1;     // ด่าน 1 (ถนน 3 เลน)
        private static readonly Image BgLevel23 = Properties.Resources.bg_level23;   // ด่าน 2-3 (ถนน 4 เลน)

        private readonly Image background;
        private readonly int srcTopGrassEnd;   // ขอบล่างของหญ้าบน (พิกเซลของรูปต้นฉบับ)
        private readonly int srcWaterEnd;      // ขอบล่างของน้ำ
        private readonly int srcRoadStart;     // ขอบบนของถนน
        private readonly int srcRoadEnd;       // ขอบล่างของถนน
        private readonly int lotusY;           // y ของแถวดอกบัว = ขอบบนของน้ำ

        public JumpingField(int roadLanes, int riverLanes, int levelSpeed, int lotusCount)
        {
            this.roadLanes = roadLanes;
            this.riverLanes = riverLanes;
            this.levelSpeed = levelSpeed;
            // เลือกรูปตามจำนวนเลนถนน พร้อมตำแหน่งขอบแต่ละแถบในรูป
            if (roadLanes == 3)   // ด่าน 1
            {
                background = BgLevel1;
                srcTopGrassEnd = 174; srcWaterEnd = 481; srcRoadStart = 577; srcRoadEnd = 832;
            }
            else                  // ด่าน 2-3
            {
                background = BgLevel23;
                srcTopGrassEnd = 161; srcWaterEnd = 472; srcRoadStart = 556; srcRoadEnd = 814;
            }

            // y ของแถวดอกบัว = ไต่ขึ้นจาก 340 ทีละ 40 ผ่านเลนถนนและเลนแม่น้ำทั้งหมด
            lotusY = (BaseY - Cell) - Cell * (roadLanes + riverLanes);
                
            // น้ำ: เริ่มที่แถวบัว สูงครอบเลนแม่น้ำ + แถวบัว
            Water = new River(0, lotusY, FieldWidth, Cell * (riverLanes + 1));

            // ถนน: y คือเลนบนสุดของถนน
            Road = new Road(0, BaseY - Cell * (roadLanes - 1), FieldWidth, Cell * roadLanes);

            // ----------------------------------------------------------------
            //  1: สร้างศัตรูเลนถนน   (ใช้ Enemy1 / Enemy2)
            for (int i = 0; i < roadLanes; i++)
            {
                int y = BaseY - Cell * i;
                int laneOffset = rnd.Next(0, 300);
                int startX1 = (laneOffset) % FieldWidth;
                int startX2 = (startX1 + FieldWidth / 2 + rnd.Next(-80, 80)) % FieldWidth;
                int speedVariation = 3 + (i % 3) * 2;

                if (i % 2 == 0)
                {
                    int speed = levelSpeed * -1 * speedVariation; // เลนคู่: วิ่งซ้าย
                    Items.Add(new Enemy1(startX1, y, speed));
                    Items.Add(new Enemy1(startX2, y, speed));
                }
                else
                {
                    int speed = levelSpeed * 1 * speedVariation;  // เลนคี่: วิ่งขวา
                    Items.Add(new Enemy2(startX1, y, speed));
                    Items.Add(new Enemy2(startX2, y, speed));
                }
            }
            //  2: สร้างซุงเลนแม่น้ำ   (ใช้ Friend1 / Friend2)
            for (int i = 0; i < riverLanes; i++)
            {
                int y = BaseY - Cell - Cell * roadLanes - Cell * i;

                int laneOffset = rnd.Next(0, 400);
                int startX1 = (laneOffset) % FieldWidth;
                int startX2 = (startX1 + FieldWidth / 2 + rnd.Next(-60, 60)) % FieldWidth;

                int speedVariation = 3 + ((i + 1) % 3) * 2;

                if (i % 2 == 0)
                {
                    int speed = levelSpeed * -1 * speedVariation; // เลนคู่: ว่ายซ้าย
                    Items.Add(new Friend1(startX1, y, speed));
                    Items.Add(new Friend1(startX2, y, speed));
                }
                else
                {
                    int speed = levelSpeed * 1 * speedVariation;  // เลนคี่: ว่ายขวา
                    Items.Add(new Friend2(startX1, y, speed));
                    Items.Add(new Friend2(startX2, y, speed));
                }
            }

                // ดอกบัวเป้าหมาย: แบ่งความกว้างเป็น (จำนวนบัว + 1) ช่อง วางที่รอยต่อ
                for (int i = 0; i < lotusCount; i++)
                {
                Items.Add(new TargetLotus(FieldWidth / (lotusCount + 1) * (i + 1) - Cell / 2, lotusY));
            }
            

                spawnTicks = rnd.Next(333, 667);
            }
        

        // ลำดับวาด: น้ำ -> ถนน -> วัตถุทั้งหมด (กบวาดทีหลังที่ FormGame)
        public void Draw(Graphics g)
        {
            DrawBackground(g);
            Water.Draw(g);
            Road.Draw(g);
            foreach (GameObject item in Items)
            {
                item.Draw(g);
            }
        }

        // วาดรูปพื้นหลังทีละแถบ ให้แต่ละแถบในรูปไปอยู่ตรงตำแหน่งของมันในเกม
        private void DrawBackground(Graphics g)
        {
            int waterBottom = BaseY - Cell * roadLanes;         // ขอบล่างของน้ำ
            int roadTop = BaseY - Cell * (roadLanes - 1);       // ขอบบนของถนน
            int roadBottom = BaseY + Cell;                      // ขอบล่างของถนน

            //       แถบบน (รูป)   แถบล่าง (รูป)    บน (เกม)     ล่าง (เกม)
            DrawBand(g, 0, srcWaterEnd, 0, waterBottom);   // น้ำ
            DrawBand(g, srcWaterEnd, srcRoadStart, waterBottom, roadTop);       // หญ้ากลาง
            DrawBand(g, srcRoadStart, srcRoadEnd, roadTop, roadBottom);    // ถนน
            DrawBand(g, srcRoadEnd, background.Height, roadBottom, FieldHeight);   // หญ้าล่าง
        }

        private void DrawBand(Graphics g, int srcTop, int srcBottom, int destTop, int destBottom)
        {
            g.DrawImage(background,
                new Rectangle(0, destTop, FieldWidth, destBottom - destTop),   // ปลายทาง: ช่วง y นี้ของเกม
                0, srcTop, background.Width, srcBottom - srcTop,               // ต้นทาง: แถบนี้ของรูป
                GraphicsUnit.Pixel);
        }
        // FormGame เรียกทุก tick
        public void UpdateSpawn()
        {
            // สุ่มเกิดไอเท็มบนถนน
            spawnTicks -= 1;
            if (spawnTicks <= 0)
            {
                // สุ่มเลนถนน (0 ถึง roadLanes - 1)
                int lane = rnd.Next(0, roadLanes);
                int itemSize = GameConfig.Scale(30);
                int y = BaseY - Cell * lane + (Cell - itemSize) / 2;
                int x = rnd.Next(0, FieldWidth - itemSize); // สุ่มตำแหน่งแกน x ในช่วง 0 .. 955

                // สุ่มชนิดไอเท็ม Heart หรือ Time
                ItemType type = (rnd.Next(2) == 0) ? ItemType.Heart : ItemType.Time;
                Items.Add(new Item(x, y, type));
                spawnTicks = rnd.Next(333, 667);
            }
        }
    }
}
