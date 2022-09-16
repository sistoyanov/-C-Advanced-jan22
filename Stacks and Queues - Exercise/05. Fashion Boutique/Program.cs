using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>(clothes);
            int racks = 1;
            int sum = capacity;

            while (stack.Any())
            {
                int current = stack.Peek();

                if (current <= sum)
                {
                    stack.Pop();
                    sum -= current;
                }
                else
                {
                    racks++;
                    sum = capacity;
                }
            }

            Console.WriteLine(racks);
        }
    }
}
