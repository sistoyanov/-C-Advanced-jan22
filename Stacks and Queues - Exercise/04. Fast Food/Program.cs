using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQty = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(orders);

            if (queue.Any())
            {
                Console.WriteLine(queue.Max());
            }

            while (queue.Any())
            {
                int currentOrd = queue.Peek();

                if (foodQty >= currentOrd)
                {
                    queue.Dequeue();
                    foodQty -= currentOrd;
                }
                else
                {
                    break;
                }
            }

            if (queue.Any())
            {
                Console.WriteLine($"Orders left: {String.Join(" ", queue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
