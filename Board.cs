using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public static  class Board
    {
        public static char[] GameBoard;

        static Board()
        {
            GameBoard = new char[9];

            for (int i = 0; i < GameBoard.Length; i++)
            {
                GameBoard[i] = ' ';
            }
        }

        public static void UpdateBoard() { }

        public static void DisplayBoard() { }
    }
}
