using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class GameManager
    {
        public Player[] Players;

        public readonly string StartMessage =
            "Start TicTacToe game!";

        public static GameManager Instance;

        public GameManager()
        {
            if(Instance == null)
                Instance = this;
        }

        /// <summary>
        /// Draw Layout on console window
        /// </summary>
        public void RenderBoard()
        {

        }

        public void DisplayStartMessage() => Console.WriteLine(StartMessage);

        public void CheckWinner()
        {

        }

        public char GetMark()
        {
            Console.Write("Where to pick? :");
            if (char.TryParse(Console.ReadKey().KeyChar.ToString(), out char input))
                return input;
            else 
                Console.WriteLine("Input 1 ~ 9");

            return ' ';
        }

        public void DrawBoard(Player targetPlayer, char mark)
        {
            
        }

        public void BeginPlayerTurn()
        {

        }

        public bool isGameOver() { return false; }

        public void ResetGame() { }
    }
}
