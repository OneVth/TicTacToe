using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public static  class Board
    {
        public static char[] gameBoard;

        static Board()
        {
            gameBoard = new char[9];

            for (int i = 0; i < gameBoard.Length; i++)
            {
                gameBoard[i] = ' ';
            }
        }
    }
}
