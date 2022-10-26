using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            SortedDictionary<string, Dictionary<string, double>> dictionary = new SortedDictionary<string, Dictionary<string, double>>();

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] commandArg = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shopName = commandArg[0];
                string product = commandArg[1];
                double price = double.Parse(commandArg[2]);

                if (!dictionary.ContainsKey(shopName))
                {
                    dictionary.Add(shopName, new Dictionary<string, double>());
                }

                dictionary[shopName].Add(product, price);
            }

            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key}->");

                foreach (var value in kvp.Value)
                {
                    Console.WriteLine($"Product: {value.Key}, Price: {value.Value}");
                }
            }
        }
    }
}
