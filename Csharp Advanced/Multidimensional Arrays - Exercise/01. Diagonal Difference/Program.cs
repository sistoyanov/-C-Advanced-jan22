using System;
using System.Linq;

namespace _01._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = elements[col];

                }

            }

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;

            for (int row = 0,  col = size -1 ; row < size; row++, col--)
            {
                primaryDiagonal += matrix[row, row];
                secondaryDiagonal += matrix[row, col];
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}
