using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Predicate<int>> predicates = new List<Predicate<int>>();
            Func<int[], List<Predicate<int>>, int[]> removedDevisible = (numbers, predicates) =>
            {
                foreach (var predicate in predicates)
                {
                    numbers = Array.FindAll(numbers, predicate).ToArray();
                }

                return numbers;
            };

            int count = int.Parse(Console.ReadLine());
            int[] numbers = Enumerable.Range(1, count).ToArray();
            HashSet<int> inputDividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();

            foreach (var divider in inputDividers)
            {
                predicates.Add(p => p % divider == 0);
            }

            Console.WriteLine(String.Join(" ", removedDevisible(numbers, predicates)));
        }
    }
}
