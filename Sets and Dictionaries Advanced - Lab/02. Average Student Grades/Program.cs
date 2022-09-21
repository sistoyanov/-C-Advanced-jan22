using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> dictionary = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);
                
                if (!dictionary.ContainsKey(name))
                {
                    dictionary.Add(name, new List<decimal>());
                }

                dictionary[name].Add(grade);
            }

            foreach (var kvp in dictionary)
            {
                Console.Write($"{kvp.Key} -> ");

                foreach (var value in kvp.Value)
                {
                    Console.Write($"{value:f2} ");
                }
                
                Console.WriteLine($"(avg: {kvp.Value.Average():f2})");
            }
        }
    }
}
