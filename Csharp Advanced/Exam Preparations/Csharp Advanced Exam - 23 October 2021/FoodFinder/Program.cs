using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] vowelsDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            char[] consonantsDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            Queue<char> vowels = new Queue<char>(vowelsDetails);
            Stack<char> consonants = new Stack<char>(consonantsDetails);
            Dictionary<string, HashSet<char>> dictionary = new Dictionary<string, HashSet<char>>
            {
                {"pear", new HashSet<char>()},
                {"flour", new HashSet<char>()},
                {"pork", new HashSet<char>()},
                {"olive", new HashSet<char>()}

            };

            while (consonants.Count > 0)
            {
                char currentVolwel = vowels.Dequeue();
                char currentConsonant = consonants.Pop();

                foreach (var kvp in dictionary)
                {
                    if (kvp.Key.Contains(currentVolwel))
                    {
                        kvp.Value.Add(currentVolwel);
                    }

                    if (kvp.Key.Contains(currentConsonant))
                    {
                        kvp.Value.Add(currentConsonant);
                    }
                }

                vowels.Enqueue(currentVolwel);
            }

            List<string> wordsFound = dictionary.Where(k => k.Key.Count() == k.Value.Count).Select(k => k.Key).ToList();
            Console.WriteLine($"Words found: {wordsFound.Count}");
            Console.WriteLine(String.Join(Environment.NewLine, wordsFound));
        }
    }
}
