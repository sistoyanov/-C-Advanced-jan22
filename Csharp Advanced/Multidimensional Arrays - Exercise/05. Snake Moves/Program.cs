using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            char[,] matrix = new char[rows, cols];
            string input = Console.ReadLine();

            Queue<char> queue = new Queue<char>(input);

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = queue.Dequeue();
                        queue.Enqueue(matrix[row, col]);

                    }
                }
                else
                {
                    for (int col = cols; col > 0; col--)
                    {
                        matrix[row, col - 1] = queue.Dequeue();
                        queue.Enqueue(matrix[row, col - 1]);

                    }
                }
                
                PrintRow(matrix, row, cols);
            }
        }

        static void PrintRow(char[,] matrix, int row, int cols)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write(matrix[row, col]);
            }

            Console.WriteLine();

            return;
        }

    }
    
}
