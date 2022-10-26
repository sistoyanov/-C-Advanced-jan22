using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] steelDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] carbonDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> steel = new Queue<int>(steelDetails);
            Stack<int> carbon = new Stack<int>(carbonDetails);

            const int Gladius = 70;
            const int Shamshir = 80;
            const int Katana = 90;
            const int Sabre = 110;
            const int Broadsword = 150;
            SortedDictionary<string, int> swords = new SortedDictionary<string, int>();

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int currentSteel = steel.Dequeue();
                int currentCarbon = carbon.Pop();
                int currentResult = currentSteel + currentCarbon;

                if (currentResult == Gladius)
                {
                    if (!swords.ContainsKey("Gladius"))
                    {
                        swords.Add("Gladius", 0);
                    }

                    swords["Gladius"] += 1;
                  
                }
                else if (currentResult == Shamshir)
                {
                    if (!swords.ContainsKey("Shamshir"))
                    {
                        swords.Add("Shamshir", 0);
                    }

                    swords["Shamshir"] += 1;
                }
                else if (currentResult == Katana)
                {
                    if (!swords.ContainsKey("Katana"))
                    {
                        swords.Add("Katana", 0);
                    }

                    swords["Katana"] += 1;
                }
                else if (currentResult == Sabre)
                {
                    if (!swords.ContainsKey("Sabre"))
                    {
                        swords.Add("Sabre", 0);
                    }

                    swords["Sabre"] += 1;
                }
                else if (currentResult == Broadsword)
                {
                    if (!swords.ContainsKey("Broadsword"))
                    {
                        swords.Add("Broadsword", 0);
                    }

                    swords["Broadsword"] += 1;
                }
                else
                {
                    carbon.Push(currentCarbon + 5);
                }
            }

            if (swords.Count > 0)
            {
                Console.WriteLine($"You have forged {swords.Values.Sum()} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Count > 0)
            {
                Console.WriteLine($"Steel left: {String.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {String.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            foreach (var sword in swords)
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }
    }
}
