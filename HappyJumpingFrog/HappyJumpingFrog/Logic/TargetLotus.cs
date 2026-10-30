using System.Drawing;
using System.Drawing.Text;

namespace HappyJumpingFrog
{
    // [เจ้าของ: โอ๊ต] ดอกบัวเป้าหมาย: กบแตะแล้วหายไป และกบกลับจุดเริ่มต้น
    public class TargetLotus : GameObject
    {
        public TargetLotus(int x, int y) : base(x, y, GameConfig.Cell, GameConfig.Cell) { }
        private Image lotus = Properties.Resources.LINE_ALBUM_171069_261025_Lotus;
        public override void Draw(Graphics g)
        {
            if (IsActive)
                g.DrawImage(lotus, X, Y, Width, Height);
        }

        public override void OnHit(PlayerFrog frog)
        {
            IsActive = false;
            frog.ResetPosition();
        }
    }
}
