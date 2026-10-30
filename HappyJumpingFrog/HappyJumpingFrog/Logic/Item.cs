using System.Drawing;

namespace HappyJumpingFrog
{
    public enum ItemType { Heart, Time }
   
    // [เจ้าของ: โอ๊ต] ไอเท็มที่สุ่มเกิดบนถนน: Heart = เพิ่มชีวิต, Time = เพิ่มเวลา
    // (FormGame ของ กู เป็นคนให้รางวัลเอง ดูจาก Type หลังจากกบชน)
    public class Item : GameObject
    {
        public ItemType Type { get; private set; }

        private int lifeTimer = 333;
        private Image Heart = Properties.Resources.LINE_ALBUM_171069_261025_1_Heart;
        private Image Time = Properties.Resources.LINE_ALBUM_171069_261025_Time;

        public Item(int x, int y, ItemType type) : base(x, y, GameConfig.Scale(30), GameConfig.Scale(30))
        {
            Type = type;
        }

        //  override Update()  — นับถอยหลังอายุ (เช่น 333 tick) หมดแล้ว IsActive = false
        public override void Update()
        {
            if (!IsActive) return;

            lifeTimer--;
            if (lifeTimer <= 0)
            {
                IsActive = false; // ไอเท็มกระพริบหายไปเพราะหมดเวลา
            }
        }

        //  override OnHit(PlayerFrog frog) — IsActive = false (เก็บแล้วหายไป)
        public override void OnHit(PlayerFrog frog)
        {
            if (!IsActive) return;

            IsActive = false;
        }

        public override void Draw(Graphics g)
        {
            if (!IsActive) return;

            // กระพริบช่วงใกล้หมดอายุ (60 tick สุดท้าย) ตามคอมเมนต์ที่เขียนไว้
            if (lifeTimer < 60 && (lifeTimer / 5) % 2 == 0) return;

            Image img = (Type == ItemType.Heart) ? Heart : Time;

            if (img != null)
            {
                g.DrawImage(img, X, Y, Width, Height);
            }
            else
            {
                // สำรอง: ถ้ารูปโหลดไม่ได้ ให้วาดวงกลมสีเหมือนเดิม
                Brush b = (Type == ItemType.Heart) ? Brushes.HotPink : Brushes.Gold;
                g.FillEllipse(b, X, Y, Width, Height);
            }
        }
    }
}
