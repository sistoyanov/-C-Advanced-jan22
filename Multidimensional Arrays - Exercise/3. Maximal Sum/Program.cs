using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row,col] = elements[col];
                }
            }

            int maxSum = int.MinValue;
            int maxSumStartRow = 0;
            int maxSumStartCol = 0;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int currentSum = 0;

                    currentSum += matrix[row,col];
                    currentSum += matrix[row,col + 1];
                    currentSum += matrix[row,col + 2];
                    currentSum += matrix[row + 1,col];
                    currentSum += matrix[row + 1,col + 1];
                    currentSum += matrix[row + 1,col + 2];
                    currentSum += matrix[row + 2,col];
                    currentSum += matrix[row + 2,col + 1];
                    currentSum += matrix[row + 2,col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxSumStartRow = row;
                        maxSumStartCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = maxSumStartRow; row < maxSumStartRow + 3; row++)
            {
                for (int col = maxSumStartCol; col < maxSumStartCol + 3; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
