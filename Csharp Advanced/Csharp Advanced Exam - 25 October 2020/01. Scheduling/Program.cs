using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _01._Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tasksDetails = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] threadsDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int taskToKill = int.Parse(Console.ReadLine());

            int currentThread = 0;
            int currentTask = 0;

            Stack<int> tasks = new Stack<int>(tasksDetails);
            Queue<int> threads = new Queue<int>(threadsDetails);

            while (true)
            {
                currentThread = threads.Peek();
                currentTask = tasks.Peek();

                if (currentThread >= currentTask)
                {
                    tasks.Pop();

                    if (currentTask == taskToKill)
                    {
                        break;
                    }

                    threads.Dequeue();
                }
                else
                {
                    if (currentTask == taskToKill)
                    {
                        break;
                    }
                    
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {currentThread} killed task {taskToKill}");
            Console.WriteLine(String.Join(" ", threads));
        }
    }
}
