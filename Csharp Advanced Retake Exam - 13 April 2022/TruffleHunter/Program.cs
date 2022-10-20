using System;
using System.Drawing;
using System.Linq;

namespace TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int blackTruffle = 0;
            int summerTruffle = 0;
            int whiteTruffle = 0;
            int boarTruffle = 0;

            for (int row = 0; row < size; row++)
            {
                char[] matrixDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = matrixDetails[col];
                }
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Stop the hunt")
            {
                string[] currentComands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = currentComands[0];
                int currentRow = int.Parse(currentComands[1]);
                int currentCol = int.Parse(currentComands[2]);

                if (IsValid(currentRow, currentCol, size))
                {
                    if (command == "Collect")
                    {
                        Colect(currentRow, currentCol, ref blackTruffle, ref summerTruffle, ref whiteTruffle, matrix);
   
                    }
                    else if (command == "Wild_Boar")
                    {
                        string direction = currentComands[3];
                        BoarColect(currentRow, currentCol, direction, ref boarTruffle, matrix, size);
                    }

                }
            }

            Console.WriteLine($"Peter manages to harvest {blackTruffle} black, {summerTruffle} summer, and {whiteTruffle} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarTruffle} truffles.");
            Print(matrix, size);
        }

        private static void BoarColect(int currentRow, int currentCol, string direction, ref int boarTruffle, char[,] matrix, int size)
        {
            if (char.IsLetter(matrix[currentRow, currentCol]))
            {
                boarTruffle++;
                matrix[currentRow, currentCol] = '-';
            }

            if (direction == "up")
            {
                for (int row = currentRow; row >= 0; row -= 2)
                {
                    if (char.IsLetter(matrix[row, currentCol]))
                    {
                        boarTruffle++;
                        matrix[row, currentCol] = '-';
                    }
                }
            }
            else if (direction == "down")
            {
                for (int row = currentRow; row < size; row += 2)
                {
                    if (char.IsLetter(matrix[row, currentCol]))
                    {
                        boarTruffle++;
                        matrix[row, currentCol] = '-';
                    }
                }
            }
            else if (direction == "left")
            {
                for (int col = currentCol; col >= 0; col -= 2)
                {
                    if (char.IsLetter(matrix[currentRow, col]))
                    {
                        boarTruffle++;
                        matrix[currentRow, col] = '-';
                    }
                }
            }
            else if (direction == "right")
            {
                for (int col = currentCol; col < size; col += 2)
                {
                    if (char.IsLetter(matrix[currentRow, col]))
                    {
                        boarTruffle++;
                        matrix[currentRow, col] = '-';
                    }
                }
            }
        }

        private static void Colect(int currentRow, int currentCol, ref int blackTruffle, ref int summerTruffle, ref int whiteTruffle, char[,] matrix)
        {
            if (matrix[currentRow, currentCol] == 'B')
            {
                blackTruffle++;
                matrix[currentRow, currentCol] = '-';
            }
            else if (matrix[currentRow, currentCol] == 'S')
            {
                summerTruffle++;
                matrix[currentRow, currentCol] = '-';
            }
            else if (matrix[currentRow, currentCol] == 'W')
            {
                whiteTruffle++;
                matrix[currentRow, currentCol] = '-';
            }
        }

        private static bool IsValid(int row, int col, int size) => (row >= 0 && row < size && col >= 0 && col < size);

        private static void Print(char[,] matrix, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
