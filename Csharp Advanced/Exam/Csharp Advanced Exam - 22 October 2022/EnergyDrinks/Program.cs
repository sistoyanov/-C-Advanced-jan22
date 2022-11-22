using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] caffeinеDetails = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] energyDrinksDetails = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int caffeineTaken = 0;
            int caffeineLifit = 300;

            Stack<int> caffeinе = new Stack<int>(caffeinеDetails);
            Queue<int> energyDrinks = new Queue<int>(energyDrinksDetails);

            while (caffeinе.Count > 0 && energyDrinks.Count > 0)
            {
                int currentCaffeine = caffeinе.Peek();
                int currentEnergyDrink = energyDrinks.Peek();
                int currentResult = currentCaffeine * currentEnergyDrink;

                if (currentResult <= caffeineLifit)
                {

                    caffeinе.Pop();
                    energyDrinks.Dequeue();
                    caffeineTaken += currentResult;
                    caffeineLifit -= currentResult;

                }
                else
                {
                    caffeinе.Pop();
                    energyDrinks.Enqueue(energyDrinks.Dequeue());

                    if (caffeineTaken > 30)
                    {
                        caffeineTaken -= 30;
                        caffeineLifit += 30;
                    }
                    
                    
                }
    
            }

            if (energyDrinks.Count > 0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {caffeineTaken} mg caffeine.");

        }
    }
}
