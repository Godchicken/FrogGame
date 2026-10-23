using System.Drawing;

namespace HappyJumpingFrog
{
    // [เจ้าของ: หลุยส์] ซุงแบบที่ 1 (คาปิบาร่า)
    public class Friend1 : FriendMonster
    {
        public Friend1(int x, int y, int speed) : base(x, y, speed) { }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.MediumPurple, X, Y, Width, Height);
        }
    }
}
