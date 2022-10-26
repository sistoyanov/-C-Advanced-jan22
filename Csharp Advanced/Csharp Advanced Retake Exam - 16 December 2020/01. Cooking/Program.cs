using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace _01._Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] liquidsDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] ingredientsDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> liquids = new Queue<int>(liquidsDetails);
            Stack<int> ingredients = new Stack<int>(ingredientsDetails);

            const int Bread = 25;
            const int Cake = 50;
            const int Pastry = 75;
            const int FruitPie = 100;

            int breadCount = 0;
            int cakeCount = 0;
            int pastryCount = 0;
            int fruitPieCount = 0;

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currentLiquid = liquids.Dequeue();
                int currentIngredident = ingredients.Peek();

                if (currentLiquid + currentIngredident == Bread)
                {
                    breadCount++;
                    ingredients.Pop();
                }
                else if (currentLiquid + currentIngredident == Cake)
                {
                    cakeCount++;
                    ingredients.Pop();
                }
                else if (currentLiquid + currentIngredident == Pastry)
                {
                    pastryCount++;
                    ingredients.Pop();
                }
                else if (currentLiquid + currentIngredident == FruitPie)
                {
                    fruitPieCount++;
                    ingredients.Pop();
                }
                else
                {
                    int ingredientToIncrease = ingredients.Pop();
                    ingredientToIncrease += 3;
                    ingredients.Push(ingredientToIncrease);

                }
            }

            if (breadCount > 0 && cakeCount > 0 && pastryCount > 0 && fruitPieCount > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {String.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {String.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            Console.WriteLine($"Bread: {breadCount}");
            Console.WriteLine($"Cake: {cakeCount}");
            Console.WriteLine($"Fruit Pie: {fruitPieCount}");
            Console.WriteLine($"Pastry: {pastryCount}");
        }
    }
}
