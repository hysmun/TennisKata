using System;
using System.Collections.Generic;
using System.Text;

namespace TennisKataLibrary
{
    public class Player
    {
        public Player(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; private set; }

        public string Surname { get; private set; }
    }
}
