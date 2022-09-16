using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfQueries = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numOfQueries; i++)
            {
                int[] commandArg = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int commandType = commandArg[0];

                if (commandType == 1)
                {
                    int elmToPush = commandArg[1];
                    stack.Push(elmToPush);
                }
                else if (commandType == 2)
                {
                    if (stack.Any())
                    {
                        stack.Pop();
                    }
                    
                }
                else if (commandType == 3)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (commandType == 4)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            Console.WriteLine($"{String.Join(", ", stack)}");
        }
    }
}
