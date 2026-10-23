using System.Drawing;

namespace HappyJumpingFrog
{
    // [เจ้าของ: หลุยส์] ศัตรูแบบที่ 1 (รถยนต์)
    public class Enemy1 : EnemyMonster
    {
        public Enemy1(int x, int y, int speed) : base(x, y, speed) { }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Red, X, Y, Width, Height);
        }
    }
}
