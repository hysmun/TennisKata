using System;
using System.Collections.Generic;
using System.Text;

namespace TennisKataLibrary
{
    public class Game
    {
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfWinningSetToWin"></param>
        public Game(int numberOfWinningSetToWin)
        {
            NumberOfWinningSetToWin = numberOfWinningSetToWin;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstPlayer"></param>
        /// <param name="secondPlayer"></param>
        /// <param name="numberOfWinningSetToWin"></param>
        public Game(Player firstPlayer, Player secondPlayer, int numberOfWinningSetToWin) : this(numberOfWinningSetToWin)
        {
            if(numberOfWinningSetToWin < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            NumberOfWinningSetToWin = numberOfWinningSetToWin;
            AddPlayer(firstPlayer);
            AddPlayer(secondPlayer);
        }


        /// <summary>
        /// Store all the data for the first player
        /// </summary>
        public PlayerScore FirstPlayer { get; private set; }


        /// <summary>
        /// Store all the data for the second player
        /// </summary>
        public PlayerScore SecondPlayer { get; private set; }

        /// <summary>
        /// number of set to win to win the game
        /// </summary>
        public int NumberOfWinningSetToWin { get; private set; }

        public bool HasBegin { get; private set; }

        /// <summary>
        /// add a player to the game
        /// </summary>
        /// <param name="p"></param>
        public void AddPlayer(Player p)
        {
            if(FirstPlayer == null)
            {
                FirstPlayer = new PlayerScore(p);
            }
            else if(SecondPlayer == null)
            {
                SecondPlayer = new PlayerScore(p);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Begin()
        {
            if(FirstPlayer == null && SecondPlayer == null)
            {
                throw new InvalidOperationException();
            }
            HasBegin = true;
        }

        /// <summary>
        /// determine the end of the game
        /// </summary>
        /// <returns></returns>
        public bool EndOfGame()
        {
            return !HasBegin || NumberOfWinningSetToWin == FirstPlayer.NumberOfSetWin || NumberOfWinningSetToWin == SecondPlayer.NumberOfSetWin;
        }

        /// <summary>
        /// get the player who won the game
        /// </summary>
        /// <returns></returns>
        public Player GetWinningPlayer()
        {
            if (!HasBegin || !EndOfGame())
                return null;
            else
            {
                if(FirstPlayer.NumberOfSetWin == NumberOfWinningSetToWin)
                {
                    return FirstPlayer.Player;
                }
                else
                {
                    return SecondPlayer.Player;
                }
            }
        }


        /// <summary>
        /// add a point to a player and contain all the score logic
        /// </summary>
        /// <param name="p"></param>
        public void AddPoint(Player p)
        {
            if (HasBegin && !EndOfGame())
            {
                PlayerScore scoringPlayer;
                PlayerScore losingPlayer;
                if (p == FirstPlayer.Player)
                {
                    scoringPlayer = FirstPlayer;
                    losingPlayer = SecondPlayer;
                }
                else if (p == SecondPlayer.Player)
                {
                    scoringPlayer = SecondPlayer;
                    losingPlayer = FirstPlayer;
                }
                else
                {
                    throw new InvalidOperationException();
                }
                
                if(scoringPlayer.Score.Points < 40)
                {
                    // increase the point
                    scoringPlayer.Score = scoringPlayer.Score.Next;
                }
                else if (scoringPlayer.Score.Points == 40 && losingPlayer.Score.Points < 40)
                {
                    //win the set
                    scoringPlayer.WinASet();
                    losingPlayer.Score = Score.Love;
                }
                else if (scoringPlayer.Score == Score.Advantage)
                {
                    //win the set
                    scoringPlayer.WinASet();
                    losingPlayer.Score = Score.Love;
                }
                else if (losingPlayer.Score == Score.Advantage)
                {
                    scoringPlayer.Score = Score.Advantage;
                    losingPlayer.Score = Score.Forty;
                }
                else if (scoringPlayer.Score == Score.Forty && losingPlayer.Score == Score.Forty)
                {
                    scoringPlayer.Score = Score.Advantage;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            else
            {
                throw new InvalidOperationException("end of game");
            }
        }
    }
}
