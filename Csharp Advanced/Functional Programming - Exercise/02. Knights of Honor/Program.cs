using System;
using System.Text;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = (names) =>
            {
                StringBuilder output = new StringBuilder();
                foreach (var name in names)
                {
                    output.AppendLine($"Sir {name}");
                }

                Console.WriteLine(output.ToString());
            };
            
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            print(input);
        }
    }
}
