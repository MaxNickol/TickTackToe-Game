using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TickTackToe
{
    public class Field
    {
        public string[,] Indexes { get; private set; }

        public Players[] Players { get; private set; }

        public void StartGame()
        {
            CreatingPlayers();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Drawing the field... \n");

            //the view of "Drawing";
            System.Threading.Thread.Sleep(500);
            Draw();
            Console.ForegroundColor = ConsoleColor.White;
            System.Threading.Thread.Sleep(500);

            Console.WriteLine();

            int count = 0;

            //creating a pair move (pl1 -> pl2 == one iteration)
            while (count < 5)
            {
                //checking the result of the game every move in the game and doing some cosmetics;
                Players[0].Turn(Players[0], Indexes);
                if (CheckTheResult())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The Player 1 wins!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Console.Clear();
                    break;
                }
                Players[1].Turn(Players[1], Indexes);

                if (CheckTheResult())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The Player 2 wins!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Console.Clear();
                    break;
                }

                count++;
            }
        }

        public bool CheckTheResult()
        {
            bool res = false;
            //checking rows;
            if (Indexes[0, 0] == Indexes[0, 1] && Indexes[0, 0] == Indexes[0, 2])
            {
                res = true;
            }
            else if (Indexes[1, 0] == Indexes[1, 1] && Indexes[1, 0] == Indexes[1, 2])
            {
                res = true;
            }
            else if (Indexes[2, 0] == Indexes[2, 1] && Indexes[2, 0] == Indexes[2, 2])
            {
                res = true;
            }

            //checking columns;
            else if (Indexes[0, 0] == Indexes[1, 0] && Indexes[0, 0] == Indexes[2, 0])
            {
                res = true;
            }
            else if (Indexes[0, 1] == Indexes[1, 1] && Indexes[0, 1] == Indexes[2, 1])
            {
                res = true;
            }
            else if (Indexes[0, 2] == Indexes[1, 2] && Indexes[0, 2] == Indexes[2, 2])
            {
                res = true;
            }

            //checking diagonals;
            else if (Indexes[0, 2] == Indexes[1, 1] && Indexes[0, 2] == Indexes[2, 0])
            {
                res = true;
            }
            else if (Indexes[0, 0] == Indexes[1, 1] && Indexes[0, 0] == Indexes[2, 2])
            {
                res = true;
            }

            return res;
        }

        private Players[] CreatingPlayers()
        {
            Players pl1 = new Player1("X", 1);
            Players pl2 = new Player1("O", 2);

            Console.WriteLine("Player 1 choose the shape you want to play: X or O");
            string input = Console.ReadLine().ToUpper();

            //restricting other chars to input, the only options are X or O;
            while (!(input == "X" || input == "O"))
            {
                Console.WriteLine("You need to input only X or O. Player 1 choose:");
                input = Console.ReadLine().ToUpper();
            }

            //validation to X or O, other chars restricted;
            if (input == "X")
            {
                pl1 = new Player1("X", 1);
                pl2 = new Player1("O", 2);

                Console.WriteLine("Player 2 your shape will be O");
                Console.WriteLine();
                Console.WriteLine($"Player 1 = {pl1.Shape}\nPlayer 2 = {pl2.Shape}");
            }
            else if (input == "O")
            {
                pl1 = new Player1("O", 1);
                pl2 = new Player1("X", 2);

                Console.WriteLine("Player 2 your shape will be X");
                Console.WriteLine();
                Console.WriteLine($"Player 1 = {pl1.Shape}\nPlayer 2 = {pl2.Shape}");
            }

            Players[] arrPl = new Players[2] { pl1, pl2 };

            Players = arrPl;

            return Players;
        }

        public void Draw()
        {
            //creating a multidimensional array to store the values of the cells;
            string[,] arr = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };

            Indexes = arr;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"| {arr[i, j]} |");
                }

                Console.WriteLine();
            }
        }
    }
}