using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public static class GameManager
    {
        public static Player[] Players;
        public static Player Winner;
        public static readonly string IntroText = "Start TicTacToe game!\n";
        public static string EndingText =>
            "Press 'Q' to quit or other key to restart.";

        static bool isGameover = false;

        public static void StartGame()
        {
            Console.Clear();
            Console.WriteLine(IntroText);

            Players = new Player[2];

            for (int i = 0; i < Players.Length; i++)
            {
                
                // Input and validate player's name
                string name = "";
                while (string.IsNullOrWhiteSpace(name))
                {
                    Console.Write($"Enter Player{i + 1}'s name: ");
                    name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                        Console.WriteLine("It's not a valid value. Please enter a valid name.");
                }

                // Input and validate player's mark
                char mark = ' ';
                while (!char.IsLetterOrDigit(mark) || mark == ' ')
                {
                    Console.Write($"Enter Player{i + 1}'s mark: ");
                    mark = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    if (!char.IsLetterOrDigit(mark) || mark == ' ')
                        Console.WriteLine("It's not a valid mark. Please enter a valid mark.");
                }


                Players[i] = new Player(name, mark);
                Console.WriteLine($"\nPlayers{i + 1}'s name: {Players[i].Name}, mark: {Players[i].Mark}");
            }

            Console.WriteLine("Let's start the game!");
            Console.ReadLine();

            while (!isGameover)
            {
                Console.Clear();
                DisplayGameLayout(Board.GameBoard);

                for (int i = 0; i < Players.Length; i++)
                {
                    ChoosePosition(Players[i]);
                    Console.Clear();
                    DisplayGameLayout(Board.GameBoard);
                    CheckWinner(Board.GameBoard, Players[i], out Winner, out isGameover);
                    if (isGameover) break;
                }
            }

            if (Winner != null)
                Console.WriteLine($"Game Over! Winner is {Winner.Name}");
            else
                Console.WriteLine("It's a draw!");
            Console.WriteLine(EndingText);
            if (Console.ReadKey().KeyChar == 'q') return;
            else RestartGame(Board.GameBoard);
        }

        /// <summary>
        /// Draw Layout on console window
        /// </summary>
        public static void DisplayGameLayout(char[,] gameBoard)
        {
            Console.WriteLine(" -----------");
            Console.WriteLine($"| {gameBoard[0, 0]} | {gameBoard[0, 1]} | {gameBoard[0, 2]} |");
            Console.WriteLine(" -----------");
            Console.WriteLine($"| {gameBoard[1, 0]} | {gameBoard[1, 1]} | {gameBoard[1, 2]} |");
            Console.WriteLine(" -----------");
            Console.WriteLine($"| {gameBoard[2, 0]} | {gameBoard[2, 1]} | {gameBoard[2, 2]} |");
            Console.WriteLine(" -----------");
        }

        public static void ChoosePosition(Player player)
        {
            while (true)
            {
                Console.WriteLine($"{player.Name}'s turn! Choose row number(1 ~ 3)");
                if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int row))
                {
                    if (row > 0 && row <= 3)
                    {
                        Console.WriteLine("\nChoose column number(1 ~ 3)");
                        if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int col))
                        {
                            if (col > 0 && col <= 3)
                            {
                                if (Board.GameBoard[row - 1, col - 1] == ' ')
                                {
                                    Board.GameBoard[row - 1, col - 1] = player.Mark;
                                    break;
                                }
                                else
                                    Console.WriteLine("\nThis position is already occupied. Please choose another position.");
                            }
                            else
                                Console.WriteLine("\nInvalid input. Please enter a number between 1 and 3.");
                        }
                        else
                            Console.WriteLine("\nYou could enter a number");
                    }
                    else
                        Console.WriteLine("\nInvalid input. Please enter a number between 1 and 3.");
                }
                else
                    Console.WriteLine("\nYou could enter a number");
            }

        }

        public static void CheckWinner(char[,] gameBoard, Player player, out Player winner, out bool isGameover)
        {
            winner = null;
            isGameover = false;

            // Check rows and columns
            for (int i = 0; i < 3; i++)
            {
                if (CheckLine(gameBoard[i, 0], gameBoard[i, 1], gameBoard[i, 2], player.Mark) ||
                    CheckLine(gameBoard[0, i], gameBoard[1, i], gameBoard[2, i], player.Mark))
                {
                    isGameover = true;
                    winner = player;
                    return;
                }
            }

            // Check diagonals
            if (CheckLine(gameBoard[0, 0], gameBoard[1, 1], gameBoard[2, 2], player.Mark) ||
                CheckLine(gameBoard[0, 2], gameBoard[1, 1], gameBoard[2, 0], player.Mark))
            {
                isGameover = true;
                winner = player;
                return;
            }

            // Check if the board is full for a draw
            isGameover = IsBoardFull(gameBoard);

            if (isGameover)
            {
                winner = null;
            }
        }

        public static bool CheckLine(char a, char b, char c, char mark)
        {
            return (a == mark && b == mark && c == mark);
        }

        public static bool IsBoardFull(char[,] gameBoard)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameBoard[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void RestartGame(char[,] gameBoard)
        {
            isGameover = false;
            Board.Initialize(gameBoard);
            StartGame();
        }
    }
}
