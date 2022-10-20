using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] mealsDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[] caloriesDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<string> meals = new Queue<string>(mealsDetails);
            Stack<int> calories = new Stack<int>(caloriesDetails);
            int mealsCount = 0;

            while (meals.Count > 0 && calories.Count > 0)
            {
                string currentMeal = meals.Dequeue();
                int currentCalories = calories.Pop();

                if (currentMeal == "salad") //350
                {
                    currentCalories -= 350;
                    mealsCount++;
                }
                else if (currentMeal == "soup") //490
                {
                    currentCalories -= 490;
                    mealsCount++;
                }
                else if (currentMeal == "pasta") //680
                {
                    currentCalories -= 680;
                    mealsCount++;
                }
                else if (currentMeal == "steak") //790
                {
                    currentCalories -= 790;
                    mealsCount++;
                }

                if (currentCalories < 0)
                {
                    int caloriesLeft = Math.Abs(currentCalories);

                    if (calories.Count > 0)
                    {
                        calories.Push(calories.Pop() - caloriesLeft);
                    }
                    
                }
                else if (currentCalories > 0)
                {
                    calories.Push(currentCalories);
                }
               
            }

            if (meals.Count <= 0)
            {
                Console.WriteLine($"John had {mealsCount} meals.");
                Console.WriteLine($"For the next few days, he can eat {String.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsCount} meals.");
                Console.WriteLine($"Meals left: {String.Join(", ", meals)}.");
            }
        }
    }
}
