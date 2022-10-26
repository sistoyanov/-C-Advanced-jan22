using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] bottlesDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> cups =new Queue<int>(cupsDetails);
            Stack<int> bottles = new Stack<int>(bottlesDetails);

            int wastedWatter = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currentCup = cups.Dequeue();

                while (currentCup > 0)
                {
                    int currentBottle = bottles.Pop();
                    currentCup -= currentBottle;

                    if (currentCup < 0)
                    {
                        wastedWatter += Math.Abs(currentCup);
                    }

                }
            }

            if (bottles.Count > 0)
            {
                Console.Write("Bottles: ");
                Console.WriteLine(String.Join(" ", bottles));
            }
            else if (cups.Count > 0)
            {
                Console.Write("Cups: ");
                Console.WriteLine(String.Join(" ", cups));
            }

            Console.WriteLine($"Wasted litters of water: {wastedWatter}");
        }
    }
}
