using System;
using System.Drawing;
using System.Linq;

namespace _08._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] symbols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var cordinates in input)
            {
                int[] currentCodinates = cordinates.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int currentRow = currentCodinates[0];
                int currentCol = currentCodinates[1];

                if (matrix[currentRow,currentCol] > 0)
                {
                    DetonateBomb(ref matrix, currentRow, currentCol, size);
                }
                
            }

            int[] resuts = CountMatrix(matrix, size);

            Console.WriteLine($"Alive cells: {resuts[0]}");
            Console.WriteLine($"Sum: { resuts[1]}");

            PrintMatrix(matrix, size);
        }

        static int[] CountMatrix(int[,] matrix, int size)
        {
            int[] results = new int[2];
            int positiveCounter = 0;
            int positeveSum = 0;
            
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row,col] > 0)
                    {
                        positiveCounter++;
                        positeveSum += matrix[row,col];
                    }
                }

            }

            results[0] = positiveCounter;
            results[1] = positeveSum;

            return results;
        }

        static void PrintMatrix(int[,] matrix, int size)
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

        static void DetonateBomb(ref int[,] matrix, int currentRow, int currentCol, int size)
        {
            int bombPower = matrix[currentRow, currentCol];
            matrix[currentRow, currentCol] = 0;

            //Up
            if (Ifexist(size, currentRow - 1, currentCol) && matrix[currentRow - 1, currentCol] > 0)
            {
                matrix[currentRow - 1, currentCol] -= bombPower;
            }

            //Down
            if (Ifexist(size, currentRow + 1, currentCol) && matrix[currentRow + 1, currentCol] > 0)
            {
                matrix[currentRow + 1, currentCol] -= bombPower;
            }

            //Right
            if (Ifexist(size, currentRow, currentCol + 1) && matrix[currentRow, currentCol + 1] > 0)
            {
                matrix[currentRow, currentCol + 1] -= bombPower;
            }

            //Left
            if (Ifexist(size, currentRow, currentCol - 1) && matrix[currentRow, currentCol - 1] > 0)
            {
                matrix[currentRow, currentCol - 1] -= bombPower;
            }

            //UpRight
            if (Ifexist(size, currentRow - 1, currentCol + 1 )&& matrix[currentRow -1 , currentCol + 1] > 0)
            {
                matrix[currentRow - 1, currentCol + 1] -= bombPower;
            }

            //UpLeft
            if (Ifexist(size, currentRow - 1, currentCol - 1) && matrix[currentRow - 1, currentCol - 1] > 0)
            {
                matrix[currentRow - 1, currentCol - 1] -= bombPower;
            }

            //DownRight
            if (Ifexist(size, currentRow + 1, currentCol + 1) && matrix[currentRow + 1, currentCol + 1] > 0)
            {
                matrix[currentRow + 1, currentCol + 1] -= bombPower;
            }

            //DownLeft
            if (Ifexist(size, currentRow + 1, currentCol - 1) && matrix[currentRow + 1, currentCol - 1] > 0)
            {
                matrix[currentRow + 1, currentCol - 1] -= bombPower;
            }
        }
        private static bool Ifexist(int size, int currentRow, int currentCol)
        {
            if (currentRow >= 0 && currentRow < size && currentCol >= 0 && currentCol < size)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
