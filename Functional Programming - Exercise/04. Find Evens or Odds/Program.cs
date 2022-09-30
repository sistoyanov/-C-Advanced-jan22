using System;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = (num) => num % 2 == 0;
            Predicate<int> isOdd = (num) => num % 2 != 0;

            int[] range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int start = range[0];
            int count = (range[1] - range[0]) + 1;
            int[] numbers = Enumerable.Range(start, count).ToArray();
            string command = Console.ReadLine();

            if (command == "even")
            {
                Console.WriteLine(String.Join(" ", Array.FindAll(numbers,isEven)));
            }
            else if (command == "odd")
            {
                Console.WriteLine(String.Join(" ", Array.FindAll(numbers, isOdd)));
            }
        }
    }
}
