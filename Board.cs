using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public  class Board
    {
        public static char[,] GameBoard { get; private set; }

        public Board()
        {
            GameBoard = new char[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameBoard[i, j] = ' ';
                }
            }
        }
    }
}
