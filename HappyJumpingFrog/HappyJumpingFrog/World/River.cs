using System.Drawing;

namespace HappyJumpingFrog
{
    // [เจ้าของ: หลุย] พื้นที่แม่น้ำ ใช้เช็คว่ากบตกน้ำ (FormGame เช็คเอง: ชนน้ำ + ไม่ได้อยู่บนซุง = ตาย)
    public class River : GameObject
    {
        public River(int x, int y, int width, int height) : base(x, y, width, height) { }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.DarkBlue, X, Y, Width, Height);
        }
    }
}
