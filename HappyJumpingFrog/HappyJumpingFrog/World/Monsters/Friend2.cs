using System.Drawing;

namespace HappyJumpingFrog
{
    // [เจ้าของ: B] ซุงแบบที่ 2 (คาปิบาร่าเหมือนกันแต่ชื่อเจมส์)
    public class Friend2 : FriendMonster
    {
        public Friend2(int x, int y, int speed) : base(x, y, speed) { }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.SaddleBrown, X, Y, Width, Height);
        }
    }
}
