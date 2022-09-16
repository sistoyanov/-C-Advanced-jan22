using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Stack<char> stack = new Stack<char>();

            foreach (var item in input)
            {
                
                if (stack.Any())
                {
                    char check = stack.Peek();

                    if (check == '{' && item == '}')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (check == '[' && item == ']')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (check == '(' && item == ')')
                    {
                        stack.Pop();
                       continue;

                    }

                }

                stack.Push(item);
            }
            Console.WriteLine(!stack.Any() ? "YES" : "NO");
        }
    }
}
