using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        public char Mark { get; private set; }

        public Player(char mark)
        {
            this.Mark = mark;
        }
    }
}
