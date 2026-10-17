using System.Drawing;

namespace HappyJumpingFrog
{
    public enum ItemType { Heart, Time }

    // [เจ้าของ: โอ๊ต] ไอเท็มที่สุ่มเกิดบนถนน: Heart = เพิ่มชีวิต, Time = เพิ่มเวลา
    // (FormGame ของ กู เป็นคนให้รางวัลเอง ดูจาก Type หลังจากกบชน)
    public class Item : GameObject
    {
        public ItemType Type { get; private set; }

        public Item(int x, int y, ItemType type) : base(x, y, 30, 30)
        {
            Type = type;
        }

        //  override Update()  — นับถอยหลังอายุ (เช่น 333 tick) หมดแล้ว IsActive = false

        //  override OnHit(PlayerFrog frog) — IsActive = false (เก็บแล้วหายไป)

        public override void Draw(Graphics g)
        {
            if (!IsActive) return;
            Brush b = (Type == ItemType.Heart) ? Brushes.HotPink : Brushes.Gold;
            g.FillEllipse(b, X, Y, Width, Height);
        }
    }
}
