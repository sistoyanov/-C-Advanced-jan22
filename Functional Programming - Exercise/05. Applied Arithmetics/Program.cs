using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int[]> add = (numsToAdd) => numsToAdd.Select(n => n + 1).ToArray();
            Func<int[], int[]> multiply = (numsToMultiply) => numsToMultiply.Select(n => n * 2).ToArray();
            Func<int[], int[]> subtract = (numsToSubtrac) => numsToSubtrac.Select(n => n - 1).ToArray();
            
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string currentCommand = command;

                if (command == "add")
                {
                   numbers = add(numbers);
                }
                else if (command == "multiply")
                {
                    numbers = multiply(numbers);
                }
                else if (command == "subtract")
                {
                    numbers = subtract(numbers);
                }
                else if (command == "print")
                {
                    Console.WriteLine(String.Join(" ", numbers));
                }
            }
        }
    }
}
