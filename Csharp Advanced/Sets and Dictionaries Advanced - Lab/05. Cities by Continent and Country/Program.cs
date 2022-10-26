using System;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> dictionary = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!dictionary.ContainsKey(continent))
                {
                    dictionary.Add(continent, new Dictionary<string, List<string>>());

                }

                if (!dictionary[continent].ContainsKey(country))
                {
                    dictionary[continent].Add(country, new List<string>());
                }

                dictionary[continent][country].Add(city);
            }

            foreach (var key in dictionary)
            {
                Console.WriteLine($"{key.Key}:");

                foreach (var value in key.Value)
                {
                    Console.WriteLine($"{value.Key} -> {string.Join(", ",value.Value)}");
                }
            }
        }
    }
}
