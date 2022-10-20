using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] waterDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            double[] flourDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Queue<double> water = new Queue<double>(waterDetails);
            Stack<double> flour = new Stack<double>(flourDetails);
            Dictionary<string, int> products = new Dictionary<string, int>()
            {
                {"Croissant", 0},
                {"Muffin", 0},
                {"Baguette", 0},
                {"Bagel", 0}
            };

            while (water.Count > 0 && flour.Count > 0)
            {
                double currentWater = water.Dequeue();
                double currentFlour = flour.Pop();
                double currentSum = currentWater + currentFlour;
                double waterPersents = (currentWater / currentSum) * 100;
                double flourPersents = (currentFlour / currentSum) * 100;

                if (waterPersents == 50 && flourPersents == 50) //•	Croissant
                {
                    products["Croissant"]++;
                }
                else if (waterPersents == 40 && flourPersents == 60) //•	Muffin
                {
                    products["Muffin"]++;
                }
                else if (waterPersents == 30 && flourPersents == 70) //•	Baguette
                {
                    products["Baguette"]++;
                }
                else if (waterPersents == 20 && flourPersents == 80) //•	Bagel
                {
                    products["Bagel"]++;
                }
                else
                {
                    double flourLeft = currentFlour - currentWater;
                    flour.Push(flourLeft);
                    products["Croissant"]++;
                }
            }

            foreach (var product in products.OrderByDescending(p => p.Value).ThenBy(p => p.Key))
            {
                if (product.Value > 0)
                {
                    Console.WriteLine($"{product.Key}: {product.Value}");
                }

            }

            if (water.Count > 0)
            {
                Console.WriteLine($"Water left: {String.Join(", ", water)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flour.Count > 0)
            {
                Console.WriteLine($"Flour left: {String.Join(", ", flour)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}
