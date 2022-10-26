using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];

                for (int j = 1; j < input.Length; j++)
                {
                    string name = input[j];

                    if (!wardrobe.ContainsKey(color))
                    {
                        wardrobe.Add(color, new Dictionary<string, int>());
                    }

                    if (!wardrobe[color].ContainsKey(name))
                    {
                        wardrobe[color].Add(name, 0);
                    }

                    wardrobe[color][name]++;
                }
            }

            string[] searched = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string searchedColor = searched[0];
            string searchedName = searched[1];

            foreach (var colors in wardrobe)
            {
                Console.WriteLine($"{colors.Key} clothes:");

                foreach (var names in colors.Value)
                {
                    string print = $"* {names.Key} - {names.Value}";

                    if (colors.Key == searchedColor && names.Key == searchedName)
                    {
                        print = $"* {names.Key} - {names.Value} (found!)";
                    }

                    Console.WriteLine(print);
                }
            }
        }
    }
}
