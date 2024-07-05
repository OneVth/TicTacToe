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
            @$"Game Over! Winner is {Winner.Name}.
Press Q to quit or other to restart.";

        static bool isGameover = false;

        public static void StartGame()
        {
            Console.Clear();
            Console.WriteLine(IntroText);

            Players = new Player[2];

            for (int i = 0; i < Players.Length; i++)
            {
                Console.Write($"Enter Player{i + 1}'s name: ");
                string name = Console.ReadLine();
                Console.Write($"Enter Player{i + 1}'s mark: ");
                char mark = Console.ReadKey().KeyChar;
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
                    // isGameover가 true여도 i가 모두 돌기 전까지 게임이 실행되는 이슈
                    ChoosePosition(Players[i]);
                    Console.Clear();
                    DisplayGameLayout(Board.GameBoard);
                    CheckWinner(Board.GameBoard, Players[i], out Winner, out isGameover);
                    if (isGameover) break;
                }
            }

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
                                    Console.WriteLine("\nIt's already filled");
                            }
                            else
                                Console.WriteLine("\nEnter a valid number");
                        }
                        else
                            Console.WriteLine("\nYou could enter a number");
                    }
                    else
                        Console.WriteLine("\nEnter a valid number");
                }
                else
                    Console.WriteLine("\nYou could enter a number");
            }

        }

        public static void CheckWinner(char[,] gameBoard, Player player, out Player winner, out bool isGameover)
        {
            winner = null;
            isGameover = false;

            if (gameBoard[0, 0] == player.Mark &&
                gameBoard[0, 1] == player.Mark &&
                gameBoard[0, 2] == player.Mark)
            {
                isGameover = true;
                winner = player;
                return;
            }

            if (gameBoard[0, 0] == player.Mark &&
                gameBoard[1, 1] == player.Mark &&
                gameBoard[2, 2] == player.Mark)
            {
                isGameover = true;
                winner = player;
                return;
            }

            if (gameBoard[0, 0] == player.Mark &&
                    gameBoard[1, 0] == player.Mark &&
                    gameBoard[2, 0] == player.Mark)
            {
                isGameover = true;
                winner = player;
                return;
            }

            if (gameBoard[0, 1] == player.Mark &&
                    gameBoard[1, 1] == player.Mark &&
                    gameBoard[2, 1] == player.Mark)
            {
                isGameover = true;
                winner = player;
                return;
            }

            if (gameBoard[0, 2] == player.Mark &&
                    gameBoard[1, 2] == player.Mark &&
                    gameBoard[2, 2] == player.Mark)
            {
                isGameover = true;
                winner = player;
                return;
            }

            if (gameBoard[1, 0] == player.Mark &&
                    gameBoard[1, 1] == player.Mark &&
                    gameBoard[1, 2] == player.Mark)
            {
                isGameover = true;
                winner = player;
                return;
            }

            if (gameBoard[0, 2] == player.Mark &&
                    gameBoard[1, 1] == player.Mark &&
                    gameBoard[2, 0] == player.Mark)
            {
                isGameover = true;
                winner = player;
                return;
            }

            if (gameBoard[2, 0] == player.Mark &&
                    gameBoard[2, 1] == player.Mark &&
                    gameBoard[2, 2] == player.Mark)
            {
                isGameover = true;
                winner = player;
                return;
            }

            if (gameBoard[0, 0] == player.Mark &&
                    gameBoard[0, 1] == player.Mark &&
                    gameBoard[0, 2] == player.Mark)
            {
                isGameover = true;
                winner = player;
                return;
            }

            // Check if the board is full for a draw
            bool isDraw = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameBoard[i, j] == ' ')
                    {
                        isDraw = false;
                        break;
                    }
                }
                if (!isDraw) break;
            }

            if (isDraw)
            {
                isGameover = false;
                winner = null;
            }
        }

        public static void RestartGame(char[,] gameBoard)
        {
            isGameover = false;
            Board.Initialize(gameBoard);
            StartGame();
        }
    }
}
