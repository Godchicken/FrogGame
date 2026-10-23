using System.Drawing;

namespace HappyJumpingFrog
{
    // [เจ้าของ: หลุยส์] พื้นที่ถนน (แค่สี่เหลี่ยมสีเทา)
    public class Road : GameObject
    {
        public Road(int x, int y, int width, int height) : base(x, y, width, height) { }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Gray, X, Y, Width, Height);
        }
    }
}
