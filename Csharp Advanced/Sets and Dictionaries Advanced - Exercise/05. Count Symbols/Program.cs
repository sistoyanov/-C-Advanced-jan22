using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] symbols = Console.ReadLine().ToCharArray();
            SortedDictionary<char, int> dictionary = new SortedDictionary<char, int>();
            
            for (int i = 0; i < symbols.Length; i++)
            {
                char currentChar = symbols[i];

                if (!dictionary.ContainsKey(currentChar))
                {
                    dictionary.Add(currentChar, 0);
                }

                dictionary[currentChar]++;
            }

            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
