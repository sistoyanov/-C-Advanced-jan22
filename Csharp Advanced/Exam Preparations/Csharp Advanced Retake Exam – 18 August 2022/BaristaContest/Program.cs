using System;
using System.Collections.Generic;
using System.Linq;

namespace BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] quantitiesCoffee = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] quantitiesMilk = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> coffee = new Queue<int>(quantitiesCoffee);
            Stack<int> milk = new Stack<int>(quantitiesMilk);
            Dictionary<string, int> drinks = new Dictionary<string, int>
            {
                {"Cortado", 0},
                {"Espresso", 0},
                {"Capuccino", 0},
                {"Americano", 0},
                {"Latte", 0}
            };

            while (coffee.Count > 0 && milk.Count > 0)
            {
                int currentCoffee = coffee.Dequeue();
                int currentMilk = milk.Pop();
                int currentSum = currentCoffee + currentMilk;

                if (currentSum == 50) //Cortado
                {
                    drinks["Cortado"]++;
                }
                else if (currentSum == 75) //Espresso
                {
                    drinks["Espresso"]++;
                }
                else if (currentSum == 100) //Capuccino
                {
                    drinks["Capuccino"]++;
                }
                else if (currentSum == 150) //Americano
                {
                    drinks["Americano"]++;
                }
                else if (currentSum == 200) //Latte
                {
                    drinks["Latte"]++;
                }
                else
                {
                    milk.Push(currentMilk - 5);
                }

            }

            if (coffee.Count == 0 && milk.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffee.Count > 0)
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
            }
            else
            {
                Console.WriteLine("Coffee left: none");
            }

            if (milk.Count > 0)
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            }
            else
            {
                Console.WriteLine("Milk left: none");
            }

            foreach (var drink in drinks.OrderBy(d => d.Value).ThenByDescending(d => d.Key))
            {
                if (drink.Value > 0)
                {
                    Console.WriteLine($"{drink.Key}: {drink.Value}");
                }
            }
        }
    }
}
