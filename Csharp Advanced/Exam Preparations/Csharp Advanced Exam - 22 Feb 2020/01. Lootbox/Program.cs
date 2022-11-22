using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstBoxDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] secondBoxDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> firstBox = new Queue<int>(firstBoxDetails);
            Stack<int> secondBox = new Stack<int>(secondBoxDetails);
            int sum = 0;

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int firstBoxIttem = firstBox.Peek();
                int secondBoxIttem = secondBox.Peek();
                int currentSum = firstBoxIttem + secondBoxIttem;

                if (currentSum % 2 == 0)
                {
                    sum += currentSum;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            if (firstBox.Count <= 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondBox.Count <= 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sum}");
            }
        }
    }
}
