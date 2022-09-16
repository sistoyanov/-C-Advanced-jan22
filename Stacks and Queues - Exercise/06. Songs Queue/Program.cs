using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ").ToArray();
            Queue<string> queue = new Queue<string>(songs);

            while (queue.Any())
            {
                string[] commandArg = Console.ReadLine().Split().ToArray();
                string commandType = commandArg[0];

                if (commandType == "Play" && queue.Any())
                {
                    queue.Dequeue();
                }
                else if (commandType == "Add")
                {
                    string songToAdd = String.Join(" ", commandArg.Skip(1));

                    if (queue.Contains(songToAdd))
                    {
                        Console.WriteLine($"{songToAdd} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(songToAdd);
                    }
                }
                else if (commandType == "Show" && queue.Any())
                {
                    Console.WriteLine($"{String.Join(", ", queue)}");
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
