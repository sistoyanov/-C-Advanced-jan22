using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _03._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int rows = size;
            int cols = size;

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            int sum = 0;

            for (int row = 0; row < rows; row++)
            {

                int idx = 0 + row;
                sum += matrix[row, idx];
                
            }

            Console.WriteLine(sum);
        }
    }
}
