using System;
using System.Collections.Generic;
using System.Text;

namespace TennisKataLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Player
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        public Player(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Surname { get; private set; }
    }
}
