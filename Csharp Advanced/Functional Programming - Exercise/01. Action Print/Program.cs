using System;
using System.Linq;
using System.Xml.Linq;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = (names) => Console.WriteLine(String.Join(Environment.NewLine, names).ToString());
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            print(input);
        }
    }
}
