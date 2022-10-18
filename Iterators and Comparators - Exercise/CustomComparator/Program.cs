using System;
using System.Linq;

namespace CustomComparator
{
    public class StarUp
    {
        static void Main(string[] args)
        {
            Func<int, int, int> customComperator = (a, b) =>
            {
                if (a % 2 == 0 && b % 2 != 0)
                {
                    return -1;
                }

                if (a % 2 != 0 && b % 2 == 0)
                {
                    return 1;
                }

                return a.CompareTo(b);
            };

            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Array.Sort(numbers, (a, b) => customComperator(a, b));
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
