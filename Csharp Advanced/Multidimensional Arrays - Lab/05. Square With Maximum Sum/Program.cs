using System;
using System.Linq;

namespace _05._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int subMatrixRows = 2;
            int subMatrixCols = 2;

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] elements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            int maxSum = 0;
            int sum = 0;
            int startRow = 0;
            int startCol = 0;


            for (int row = 0; row < rows - subMatrixRows + 1 ; row++)
            {

                for (int col = 0; col < cols - subMatrixCols + 1 ; col++)
                {
                    sum+= matrix[row, col];
                    sum+= matrix[row, col + 1];
                    sum+= matrix[row + 1, col];
                    sum+= matrix[row + 1, col + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startRow = row;
                        startCol = col;
                    }

                    sum = 0;
                }

            }

            Console.WriteLine($"{matrix[startRow,startCol]} {matrix[startRow,startCol + 1]}");
            Console.WriteLine($"{matrix[startRow + 1,startCol]} {matrix[startRow + 1,startCol + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
