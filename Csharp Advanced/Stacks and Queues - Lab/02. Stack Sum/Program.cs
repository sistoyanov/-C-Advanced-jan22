using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(input);
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArg = command.Split();

                if(commandArg[0].ToLower() == "add")
                {
                    int num1 = int.Parse(commandArg[1]);
                    int num2 = int.Parse(commandArg[2]);
                    stack.Push(num1);
                    stack.Push(num2);
                }
                else if(commandArg[0].ToLower() == "remove")
                {
                    int count = int.Parse(commandArg[1]);

                    if (count <= stack.Count)
                    {
                        for (int i = 1; i <= count ; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
