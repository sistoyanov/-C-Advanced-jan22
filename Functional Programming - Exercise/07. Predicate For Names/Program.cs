using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string[], int, string[]> filterByLength = (names, length) => names.Where(n => n.Length <= length).ToArray();

            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(String.Join(Environment.NewLine, filterByLength(names, length)));
        }
    }
}
