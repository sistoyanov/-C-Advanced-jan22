using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] jaggedArr = new int[size][];

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaggedArr[i] = elements;
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandArg = input.Split().ToArray();
                string commandType = commandArg[0];
                int row = int.Parse(commandArg[1]);
                int col = int.Parse(commandArg[2]);
                int value = int.Parse(commandArg[3]);

                if (row >= 0 && row < jaggedArr.Length && col >= 0 && col < jaggedArr[row].Length)
                {
                    if (commandType == "Add")
                    {
                        jaggedArr[row][col]+= value;
                    }
                    else if (commandType == "Subtract")
                    {
                        jaggedArr[row][col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                } 
            }

            foreach (var item in jaggedArr)
            {
                Console.WriteLine(String.Join(" ", item));
            }
        }
    }
}
