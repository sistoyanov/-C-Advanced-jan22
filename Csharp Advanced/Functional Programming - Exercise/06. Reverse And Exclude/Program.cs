using System;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int, int[]> removeDevisible = (numbers, divider) => numbers.Where(x => x % divider != 0).ToArray();

            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int devider = int.Parse(Console.ReadLine());
            numbers = removeDevisible(numbers, devider).Reverse().ToArray();
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
