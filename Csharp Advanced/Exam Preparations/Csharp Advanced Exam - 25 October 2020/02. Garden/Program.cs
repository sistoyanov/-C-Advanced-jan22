using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int[,] garden = new int[rows, cols];

            List<int[]> flowers = new List<int[]>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    garden[row, col] = 0;
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] newFlowerPosition = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (IsValid(rows, cols, newFlowerPosition[0], newFlowerPosition[1]))
                {
                    flowers.Add(newFlowerPosition);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            foreach (var flower in flowers)
            {
                int currentFlowerRow = flower[0];
                int currentFlowerCol = flower[1];

                FlowerBloom(garden, rows, cols, currentFlowerRow, currentFlowerCol);
            }

            Print(garden, rows, cols);
        }

        public static void FlowerBloom(int[,] garden, int rows, int cols, int flowerRow, int flowerCol)
        {
            garden[flowerCol, flowerCol] = 1;

            //Up
            for (int i = flowerRow - 1; i >= 0; i--)
            {
                garden[i, flowerCol] += 1;
            }

            //Down
            for (int j = flowerRow + 1; j < rows; j++)
            {
                garden[j, flowerCol] += 1;
            }

            //Left
            for (int k = flowerCol - 1; k >= 0; k--)
            {
                garden[flowerRow, k] += 1;
            }

            //Right
            for (int l = flowerCol + 1; l < cols; l++)
            {
                garden[flowerRow, l] += 1;
            }
        }

        public static bool IsValid(int rows, int cols, int row, int col)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }

        public static void Print(int[,] garden, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{garden[row, col]} ");
                }

                Console.WriteLine();
            }
        }

    }
}
