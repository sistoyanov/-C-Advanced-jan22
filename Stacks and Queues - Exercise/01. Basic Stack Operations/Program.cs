using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numArg = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numsToPush = numArg[0];
            int numsToPop = numArg[1];
            int numToFound = numArg[2];

            int[]numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(numbers);

            for (int i = 0; i < numsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(numToFound))
            {
                Console.WriteLine("true");
            }
            else if (stack.Any())
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
