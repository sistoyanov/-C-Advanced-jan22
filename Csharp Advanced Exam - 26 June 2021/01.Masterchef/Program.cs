using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ingredientsDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] freshnessDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> ingredients = new Queue<int>(ingredientsDetails);
            Stack<int> freshness = new Stack<int>(freshnessDetails);

            const int DippingSauce = 150;
            const int GreenSalade = 250;
            const int ChocolateCake = 300;
            const int Lobster = 400;

            int dippingSauceCounnt = 0;
            int greenSaladeCount = 0;
            int chocolateCakeCount = 0;
            int lobsterCount = 0;

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                int currentIngredient = ingredients.Dequeue();

                if (currentIngredient == 0)
                {
                    continue;
                }

                int currentFeshness = freshness.Peek();
                int freshnessLevel = currentIngredient * currentFeshness;

                if (freshnessLevel == DippingSauce)
                {
                    dippingSauceCounnt++;
                    freshness.Pop();

                }
                else if (freshnessLevel == GreenSalade)
                {
                    greenSaladeCount++;
                    freshness.Pop();
                }
                else if (freshnessLevel == ChocolateCake)
                {
                    chocolateCakeCount++;
                    freshness.Pop();
                }
                else if (freshnessLevel == Lobster)
                {
                    lobsterCount++;
                    freshness.Pop();
                }
                else
                {
                    freshness.Pop();
                    ingredients.Enqueue(currentIngredient + 5);
                }
            }

            if (dippingSauceCounnt > 0 && greenSaladeCount > 0 && chocolateCakeCount > 0 && lobsterCount > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            if (chocolateCakeCount > 0)
            {
                Console.WriteLine($" # Chocolate cake --> {chocolateCakeCount}");
            }

            if (dippingSauceCounnt > 0)
            {
                Console.WriteLine($" # Dipping sauce --> {dippingSauceCounnt}");
            }

            if (greenSaladeCount > 0)
            {
                Console.WriteLine($" # Green salad --> {greenSaladeCount}");
            }

            if (lobsterCount > 0)
            {
                Console.WriteLine($" # Lobster --> {lobsterCount}");
            }
        }
    }
}
