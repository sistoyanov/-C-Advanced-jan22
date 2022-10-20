using System;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] whiteTilesDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] greyTilesDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> greyTiles = new Queue<int>(greyTilesDetails);
            Stack<int> whiteTiles = new Stack<int>(whiteTilesDetails);
            Dictionary<string, int> locations = new Dictionary<string, int>
            {
                {"Sink", 0},
                {"Oven", 0},
                {"Countertop", 0},
                {"Wall", 0},
                {"Floor", 0}
            };

            while (greyTiles.Count > 0 && whiteTiles.Count > 0)
            {
                int currentGreyTile = greyTiles.Peek();
                int currentWhiteTile = whiteTiles.Peek();

                if (currentGreyTile == currentWhiteTile)
                {
                    int newTile = currentGreyTile + currentWhiteTile;
                    greyTiles.Dequeue();
                    whiteTiles.Pop();
                    
                    if (newTile == 40) //Sink
                    {
                        locations["Sink"]++;
                    }
                    else if (newTile == 50) //Oven
                    {
                        locations["Oven"]++;
                    }
                    else if (newTile == 60) //Countertop
                    {
                        locations["Countertop"]++;
                    }
                    else if (newTile == 70) //Wall
                    {
                        locations["Wall"]++;
                    }
                    else //Floor
                    {
                        locations["Floor"]++;
                    }
                }
                else
                {
                    whiteTiles.Push(whiteTiles.Pop() / 2);
                    greyTiles.Enqueue(greyTiles.Dequeue());
                }
            }

            if (whiteTiles.Count > 0)
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }

            if (greyTiles.Count > 0)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            foreach (var location in locations.OrderByDescending(l => l.Value).ThenBy(l => l.Key))
            {
                if (location.Value > 0)
                {
                    Console.WriteLine($"{location.Key}: {location.Value}");
                }
            }
        }
    }
}
