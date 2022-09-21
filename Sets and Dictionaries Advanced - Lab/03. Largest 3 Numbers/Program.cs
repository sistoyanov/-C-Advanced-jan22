using System;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().
                            Split(" ", StringSplitOptions.RemoveEmptyEntries).
                            Select(int.Parse).
                            OrderByDescending(n => n).
                            Take(3).
                            ToArray();

            Console.WriteLine($"{String.Join(" ", numbers)}");
        }
    }
}
