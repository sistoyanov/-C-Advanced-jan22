using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, int> persons = new Dictionary<string, int>();

            for (int i = 0; i < count; i++)
            {
                string[] currentPersonDetails = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = currentPersonDetails[0];
                int age = int.Parse(currentPersonDetails[1]);

                if (!persons.ContainsKey(name))
                {
                    persons.Add(name, age);
                }
            }

            string condition = Console.ReadLine();
            int ageToDisplay = int.Parse(Console.ReadLine());
            string[] format = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Print(condition, ageToDisplay, format, persons);
        }

        private static void Print(string condition, int ageToDisplay, string[] format, Dictionary<string, int> persons)
        {
     
            if (condition == "older")
            {
                persons = persons.Where(p => p.Value >= ageToDisplay).ToDictionary(x => x.Key, y => y.Value);

                foreach (var kvp in persons)
                {
                    if (format.Length > 0)
                    {
                        if (format[0] == "name")
                        {
                            Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                        }
                        else
                        {
                            Console.WriteLine($"{kvp.Value} - {kvp.Key}");
                        }
                    }
                    else
                    {
                        if (format[0] == "name")
                        {
                            Console.WriteLine($"{kvp.Key}");
                        }
                        else
                        {
                            Console.WriteLine($"{kvp.Value}");
                        }
                    }
                }
            }
            else
            {
                persons = persons.Where(p => p.Value < ageToDisplay).ToDictionary(x => x.Key, y => y.Value);

                foreach (var kvp in persons)
                {
                    if (format.Length > 1)
                    {
                        if (format[0] == "name")
                        {
                            Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                        }
                        else
                        {
                            Console.WriteLine($"{kvp.Value} - {kvp.Key}");
                        }
                    }
                    else
                    {
                        if (format[0] == "name")
                        {
                            Console.WriteLine($"{kvp.Key}");
                        }
                        else
                        {
                            Console.WriteLine($"{kvp.Value}");
                        }
                    }
                }
            }
        }
    }
}
