using System;

namespace _07._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            long[][] pascal = new long[size][];

            for (int row = 0; row < size; row++)
            {
                pascal[row] = new long[row + 1];

                for (int col = 0; col < pascal[row].Length; col++)
                {
                    long currentValue = 0;

                    if (row == 0)
                    {
                        pascal[row][col] = 1;
                        continue;
                    }

                    if (col > 0 && row > 0)
                    {
                        currentValue += pascal[row - 1][col - 1];
                    }

                    if (pascal[row].Length - 1 > col)
                    {
                        currentValue += pascal[row - 1][col];
                    }

                    pascal[row][col] = currentValue;
                }
            }

            foreach (var item in pascal)
            {
                Console.WriteLine(String.Join(" ", item));
            }
        }
    }
}
