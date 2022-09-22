using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            SortedSet<string> set = new SortedSet<string>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < input.Length; j++)
                {
                    set.Add(input[j]);
                }
                
            }

            Console.WriteLine(String.Join(" ", set));

        }
    }
}
