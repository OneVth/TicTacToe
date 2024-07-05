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
                DisplayGameLayout(Board.GameBoard);

                ChoosePosition();
                CheckWinner();

            }
        }

        /// <summary>
        /// Draw Layout on console window
        /// </summary>
        public static void DisplayGameLayout(char[,] _gameBoard)
        {
            Console.WriteLine(" -----------");
            Console.WriteLine($"| {_gameBoard[0, 0]} | {_gameBoard[0, 1]} | {_gameBoard[0, 2]} |");
            Console.WriteLine(" -----------");
            Console.WriteLine($"| {_gameBoard[1, 0]} | {_gameBoard[1, 1]} | {_gameBoard[1, 2]} |");
            Console.WriteLine(" -----------");
            Console.WriteLine($"| {_gameBoard[2, 0]} | {_gameBoard[2, 1]} | {_gameBoard[2, 2]} |");
            Console.WriteLine(" -----------");
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
