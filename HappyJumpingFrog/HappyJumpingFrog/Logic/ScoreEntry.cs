namespace HappyJumpingFrog
{
    // [เจ้าของ: โอ๊ต] ข้อมูล 1 แถวในตารางคะแนน
    public class ScoreEntry
    {
        public string Name { get; private set; }
        public int Score { get; private set; }

        public ScoreEntry(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
}
