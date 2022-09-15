using System;
using System.Collections;
using System.Collections.Generic;

namespace _07._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split();
            int nums = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(kids);
            int tosses = 1;

            while (queue.Count > 1)
            {
                string currentKid = queue.Dequeue();

                if (tosses == nums)
                {
                    Console.WriteLine($"Removed {currentKid}");
                    tosses = 1;
                    continue;
                }

                tosses++;
                queue.Enqueue(currentKid);
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
