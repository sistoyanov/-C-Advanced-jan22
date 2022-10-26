using System;
using System.Linq;

namespace _04._Symbol_in_Matrix
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
                char[] elements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            char searchedSymbol = char.Parse(Console.ReadLine());
            int resultRow = 0;
            int resultCol = 0;
            bool isFound = false;


            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (searchedSymbol == matrix[row, col])
                    {
                        isFound = true;
                        resultRow = row;
                        resultCol = col;
                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }

            Console.WriteLine(isFound ? $"({resultRow}, {resultCol})" : $"{searchedSymbol} does not occur in the matrix ");
        }
    }
}
