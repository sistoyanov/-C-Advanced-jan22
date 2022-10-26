using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < count; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(currentNum))
                {
                    numbers.Add(currentNum, 0);
                }

                numbers[currentNum]++;
            }

            Console.WriteLine(numbers.Single(n => n.Value % 2 == 0).Key);
        }
    }
}
