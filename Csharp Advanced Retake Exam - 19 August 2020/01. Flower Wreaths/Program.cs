using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] liliesDetails = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] rosesDetails = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> lilies = new Stack<int>(liliesDetails);
            Queue<int> roses = new Queue<int>(rosesDetails);

            int wreathCount = 0;
            int storageCount = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int currentLiliesCount = lilies.Peek();
                int currentRosesCount = roses.Peek();

                if (currentLiliesCount + currentRosesCount == 15)
                {
                    roses.Dequeue();
                    lilies.Pop();
                    wreathCount++;
                }
                else if (currentLiliesCount + currentRosesCount > 15)
                {
                    int liliesToDecrease = lilies.Pop();
                    liliesToDecrease -= 2;
                    lilies.Push(liliesToDecrease);
                }
                else
                {
                    storageCount += currentLiliesCount + currentRosesCount;
                    roses.Dequeue();
                    lilies.Pop();
                }

            }

            while (storageCount >= 15)
            {
                wreathCount++;
                storageCount -= 15;
            }

            if (wreathCount >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathCount} wreaths more!");
            }

        }
    }
}
