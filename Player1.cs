using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToe
{
    public class Player1 : Players
    {
        public Player1(string shape, int id) : base(shape, id)
        {
        }

        public override string Turn(Players pl, string[,] obj)
        {
            Console.WriteLine($"The Player {pl.ID}, it's your turn.");
            string attempt = Console.ReadLine();

            int parse = 0;

            bool tryParse = int.TryParse(attempt, out parse);

            // succeed parse with the drawing the move of the player;
            if (tryParse)
            {
                for (int i = 0; i < obj.GetLength(0); i++)
                {
                    for (int j = 0; j < obj.GetLength(1); j++)
                    {
                        if (attempt == obj[i, j])
                        {
                            obj[i, j] = pl.Shape;
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"| {obj[i, j]} |");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine();
                }
            }

            //failed parsing with drawing the full previous move of the player;
            while (!(parse >= 1 && parse < 10))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You should input a digit from 1 to 9");
                Console.ForegroundColor = ConsoleColor.White;

                attempt = Console.ReadLine();
                bool effort = int.TryParse(attempt, out parse);

                for (int i = 0; i < obj.GetLength(0); i++)
                {
                    for (int j = 0; j < obj.GetLength(1); j++)
                    {
                        if (attempt == obj[i, j])
                        {
                            obj[i, j] = pl.Shape;
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"| {obj[i, j]} |");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine();
                }
            }

            return attempt;
        }
    }
}