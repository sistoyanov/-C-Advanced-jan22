using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            Stack<string> memory = new Stack<string>();
            memory.Push(String.Empty);


            for (int i = 0; i < number; i++)
            {
                string[] commandArg = Console.ReadLine().Split().ToArray();
                string commandType = commandArg[0];

                if (commandType == "1")
                {
                    string strToAdd = commandArg[1];
                    text.Append(strToAdd);
                    memory.Push(text.ToString());
                }
                else if (commandType == "2")
                {
                    int elmToRemove = int.Parse(commandArg[1]);
                    text = text.Remove(text.Length - elmToRemove, elmToRemove);
                    memory.Push(text.ToString());
                }
                else if (commandType == "3")
                {
                    int elmToShow = int.Parse(commandArg[1]);
                    Console.WriteLine(text[elmToShow -1]);
                }
                else if (commandType == "4")
                {
                    memory.Pop();
                    string previousVersion = memory.Peek();

                    text = new StringBuilder(previousVersion);
                }
            }
        }
    }
}
