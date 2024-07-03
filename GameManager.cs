using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public static class GameManager
    {
        public static Player[] Players;

        public static readonly string IntroText = "Start TicTacToe game!";
        public static readonly string EndingText;

        public static void StartGame()
        {
            Console.WriteLine(IntroText);

            while (true)
            {
                Console.Clear();
                DisplayGameLayout();

                ChoosePosition();
                CheckWinner();

            }
        }

        /// <summary>
        /// Draw Layout on console window
        /// </summary>
        public static void DisplayGameLayout()
        {
            char[,] gameBoard = Board.GameBoard;

            Console.WriteLine("");
        }

        public static void ChoosePosition()
        {
            throw new NotImplementedException();
        }

        public static bool CheckWinner()
        {
            throw new NotImplementedException();
        }

        public static void ResetGame() 
        {
            throw new NotImplementedException();
        }
    }
}
