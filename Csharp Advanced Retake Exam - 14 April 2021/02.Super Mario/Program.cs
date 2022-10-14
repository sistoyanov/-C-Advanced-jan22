using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _02.Super_Mario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int live = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] field = new char[rows][];

            int marioRow = 0;
            int marioCol = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] rowDetails = Console.ReadLine().ToCharArray();
                field[row] = rowDetails;

                if (rowDetails.Contains('M'))
                {
                    marioRow = row;
                    marioCol = rowDetails.ToList().IndexOf('M');
                }
            }

            while (true)
            {
                string[] commandDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currentCommand = commandDetails[0];
                int enemyRow = int.Parse(commandDetails[1]);
                int enemyCol = int.Parse(commandDetails[2]);

                field[enemyRow][enemyCol] = 'B';
                field[marioRow][marioCol] = '-';
                live--;


                if (currentCommand == "W" && marioRow - 1 >= 0) //up
                {
                    marioRow--;

                }
                else if (currentCommand == "S" && marioRow + 1 < rows) // down
                {
                    marioRow++;
                }
                else if (currentCommand == "A" && marioCol - 1 >= 0) // left
                {
                    marioCol--;
                }
                else if (currentCommand == "D" && marioCol + 1 < field[0].Length) //right
                {
                    marioCol++;
                }



                if (field[marioRow][marioCol] == 'B')
                {
                    live -= 2;
                }
                else if (field[marioRow][marioCol] == 'P')
                {
                    field[marioRow][marioCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {live}");
                    break;
                }


                if (live <= 0)
                {
                    field[marioRow][marioCol] = 'X';
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    break;
                }

                field[marioRow][marioCol] = 'M';
            }

            Print(field);
        }

        private static void Print(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    Console.Write(field[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}
