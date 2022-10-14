using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Warm_Winter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] hatsDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] scarfsDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> hats = new Stack<int>(hatsDetails);
            Queue<int> scarfs = new Queue<int>(scarfsDetails);
            List<int> sets = new List<int>();

            while (hats.Count >0 && scarfs.Count > 0)
            {
                int currentHat = hats.Peek();
                int currentScarf = scarfs.Peek();

                if (currentHat > currentScarf)
                {
                    sets.Add(currentHat + currentScarf);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (currentHat < currentScarf)
                {
                    hats.Pop();
                }
                else
                {
                    scarfs.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(String.Join(" ", sets));
        }
    }
}
