using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._The_Fight_for_Gondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int waveCount = int.Parse(Console.ReadLine());
            int[] platesDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<int> plates = new List<int>(platesDetails);
            Stack<int> orcs = new Stack<int>();

            bool isLost = false;

            for (int i = 1; i <= waveCount; i++)
            {
                int[] orcDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                orcs = new Stack<int>(orcDetails);

                if (i % 3 == 0)
                {
                    plates.Add(int.Parse(Console.ReadLine()));
                }

                while (plates.Count > 0 && orcs.Count > 0)
                {

                    int currentOrc = orcs.Peek();
                    int currentPlate = plates[0];

                    if (currentOrc > currentPlate)
                    {
                        orcs.Push(orcs.Pop() - currentPlate);
                        plates.Remove(currentPlate);

                    }
                    else if (currentOrc < currentPlate)
                    {

                        plates[0] -= currentOrc;
                        orcs.Pop();
                    }
                    else
                    {
                        orcs.Pop();
                        plates.Remove(currentPlate);
                    }
              
                }

                if (plates.Count <= 0)
                {
                    isLost = true;
                    break;
                }
            }

            if (isLost)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {String.Join(", ", orcs)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {String.Join(", ", plates)}");
            }
        }
    }
}
