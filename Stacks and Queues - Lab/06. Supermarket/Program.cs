using System;
using System.Collections;
using System.Collections.Generic;

namespace _06._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> people = new Queue<string>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                if (input != "Paid")
                {
                    people.Enqueue(input);
                }

                if (input == "Paid")
                {
                    while (people.Count > 0)
                    {
                        Console.WriteLine(people.Dequeue());
                    }
                }
                
            }

            Console.WriteLine($"{people.Count} people remaining.");
        }
    }
}
