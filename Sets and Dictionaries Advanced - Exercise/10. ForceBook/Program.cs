using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<string>> sides = new SortedDictionary<string, SortedSet<string>>();
            string input = string.Empty;
            string forceSide = string.Empty;
            string forceUser = string.Empty;
            string[] separators = { " | ", " -> " };


            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] commands = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                if (input.Contains(" | "))
                {
                    forceSide = commands[0];
                    forceUser = commands[1];

                    if (!sides.Values.Any(v => v.Contains(forceUser)))
                    {
                        if (!sides.ContainsKey(forceSide))
                        {
                            sides.Add(forceSide, new SortedSet<string>());
                        }

                        sides[forceSide].Add(forceUser);
                    }
   
                }
                else if (input.Contains(" -> "))
                {
                    forceUser = commands[0];
                    forceSide = commands[1];

                    foreach (var side in sides)
                    {
                        if (side.Value.Contains(forceUser))
                        {
                            side.Value.Remove(forceUser);
                            break;
                        }
                    }
                    
                    
                    if (!sides.ContainsKey(forceSide))
                    {
                        sides.Add(forceSide, new SortedSet<string>());
                    }

                    sides[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            var sortedSides = sides.OrderByDescending(v => v.Value.Count);

            foreach (var side in sortedSides)
            {
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                    foreach (var user in side.Value)
                    {
                        Console.WriteLine($"! {user}");
                    }
                }

            }
        }

    }
}
