using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);

                if (stack.Count == 3)
                {
                    int num1 = int.Parse(stack.Pop());
                    string sign = stack.Pop();
                    int num2 = int.Parse(stack.Pop());
                    int result = 0;

                    if (sign == "+")
                    {
                        result = num1 + num2;
                    }
                    if (sign == "-")
                    {
                        result = num2 - num1;
                    }

                    stack.Push(result.ToString());
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
