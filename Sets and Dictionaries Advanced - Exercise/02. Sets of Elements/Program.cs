using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] count = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int firstCount = count[0];
            int secondCount = count[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < firstCount; i++)
            {
                int firstNum = int.Parse(Console.ReadLine());
                firstSet.Add(firstNum);
            }

            for (int i = 0; i < secondCount; i++)
            {
                int secondNum = int.Parse(Console.ReadLine());
                secondSet.Add(secondNum);
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(String.Join(" ", firstSet));
        }
    }
}
