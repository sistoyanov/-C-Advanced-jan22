using System;
using System.Linq;

namespace _06._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArr = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jaggedArr[row] = elements;
            }

            AnalyzeJaggedArr(ref jaggedArr);

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandArg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string commadType = commandArg[0];
                int row = int.Parse(commandArg[1]);
                int col = int.Parse(commandArg[2]);
                int value = int.Parse(commandArg[3]);

                if (isIdxValid(jaggedArr, row, col))
                {
                    if (commadType == "Add")
                    {
                        jaggedArr[row][col] += value;
                    }
                    else if (commadType == "Subtract")
                    {
                        jaggedArr[row][col] -= value;
                    }
                }
            }

            foreach (int[] item in jaggedArr)
            {
                Console.WriteLine(String.Join(" ", item));
            }
        }
        static void AnalyzeJaggedArr(ref int[][] jaggedArr)
        {
            for (int row = 0; row < jaggedArr.Length - 1; row++)
            {
                if (jaggedArr[row].Length == jaggedArr[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArr[row].Length; col++)
                    {
                        jaggedArr[row][col] *= 2;
                        jaggedArr[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArr[row].Length; col++)
                    {
                        jaggedArr[row][col] /= 2;
                    }

                    for (int col = 0; col < jaggedArr[row + 1].Length; col++)
                    {
                        jaggedArr[row + 1][col] /= 2;
                    }
                }
            }
        }
        static bool isIdxValid(int[][] jaggedArr, int row, int col)
        {
            if (row >= 0 && row < jaggedArr.Length && col >= 0 && col < jaggedArr[row].Length)
            {
                return true;
            }

            return false;

        }
    }
}
