using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numArg = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numsToPush = numArg[0];
            int numsToPop = numArg[1];
            int numToFound = numArg[2];

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < numsToPop; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(numToFound))
            {
                Console.WriteLine("true");
            }
            else if (queue.Any())
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
