using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        public string Name { get; private set; }
        public char Mark { get; private set; }

        public Player(string name, char mark)
        {
            this.Name = name;
            this.Mark = mark;
        }
    }
}
