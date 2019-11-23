namespace TennisKataLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayerScore
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="score"></param>
        public PlayerScore(Player player, Score score)
        {
            Player = player;
            Score = score;
            NumberOfSetWin = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public PlayerScore(Player player)
        {
            Player = player;
            Score = Score.Love;
            NumberOfSetWin = 0;
        }


        /// <summary>
        /// the player
        /// </summary>
        public Player Player { get; private set; }


        /// <summary>
        /// the current score of the player
        /// </summary>
        public Score Score { get; set; }

        /// <summary>
        /// number of wining set
        /// </summary>
        public int NumberOfSetWin { get; private set; }

        public void WinASet()
        {
            NumberOfSetWin++;
            Score = Score.Love;
        }
    }
}
