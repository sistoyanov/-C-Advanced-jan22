using System;
using System.Linq;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> checkLength = (name, length) => name.Sum(ch => ch) >= length;
            Func<string[], int, Func<string, int, bool>, string> getFirst = (names, lenght, checkLength) => names.FirstOrDefault(name => checkLength(name, lenght));
            
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(getFirst(names, length, checkLength));
        }
    }
}
