using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        bool isTurn = false;
        public string Name { get; private set; }
        public char Mark { get; private set; }
        public bool IsTurn { get { return isTurn; } private set { isTurn = value; } }

        public Player(string name, char mark)
        {
            this.Name = name;
            this.Mark = mark;
        }

        public void ChangeTurn()
        {
            throw new NotImplementedException();
        }
    }
}
