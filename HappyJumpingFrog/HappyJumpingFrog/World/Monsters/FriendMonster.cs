namespace HappyJumpingFrog
{
    // [เจ้าของ: หลุย] แม่ของ "เพื่อน" (ซุง): วิ่งวนซ้าย-ขวา ชนแล้ว "พากบไปด้วย"
    public abstract class FriendMonster : GameObject
    {
        protected int speed;

        protected FriendMonster(int x, int y, int speed) : base(x, y, 120, 40)
        {
            this.speed = speed;
        }

        //  override Update()  — วิ่งวนเหมือน EnemyMonster
        //   (ถ้าโค้ดซ้ำกันมาก ลองสร้างคลาสกลางให้ทั้งสองแม่สืบทอด แล้วแจ้งทีมก่อน)

        //  override OnHit(PlayerFrog frog)
        //   frog.Carry(speed);
    }
}
