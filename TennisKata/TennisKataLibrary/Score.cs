using System;
using System.Runtime.Serialization;

namespace TennisKataLibrary
{
    public class Score
    {
        public static Score Forty = new Score("forty", 40);
        public static Score Advantage = new Score("advantage", 40);
        public static Score Thirty = new Score("thirty", 30, Forty);
        public static Score Fifteen = new Score("fifteen", 15, Thirty);
        public static Score Love = new Score("love", 0, Fifteen);

        private Score(string name, int points, Score s)
        {
            Name = name;
            Points = points;
            Next = s;
        }

        private Score(string name, int points)
        {
            Name = name;
            Points = points;
            Next = null;
        }

        /// <summary>
        /// the name of the score
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// number of points associated
        /// </summary>
        public int Points { get; private set; }

        /// <summary>
        /// the next score after the current one
        /// </summary>
        public Score Next { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
