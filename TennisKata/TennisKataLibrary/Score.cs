using System;
using System.Runtime.Serialization;

namespace TennisKataLibrary
{
    public class Score
    {
        public static Score Love = new Score("love", 0);
        public static Score Fifteen = new Score("fifteen", 15);
        public static Score Thirty = new Score("thirty", 30);
        public static Score Forty = new Score("forty", 40);
        public static Score Advantage = new Score("advantage", 40);

        private Score(string name, int points)
        {
            Name = name;
            Points = points;
        }

        public string Name { get; private set; }
        public int Points { get; private set; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if(obj is Score s) 
                return Equals(s);
            return false;
        }
    }
}
