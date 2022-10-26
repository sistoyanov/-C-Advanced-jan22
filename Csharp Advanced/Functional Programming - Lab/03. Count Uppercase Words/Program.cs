using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(Environment.NewLine, Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)       
                       .Where(w => char.IsUpper(w[0]))));
        }
    }
}
