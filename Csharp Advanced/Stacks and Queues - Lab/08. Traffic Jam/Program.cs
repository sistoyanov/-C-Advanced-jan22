using System;
using System.Collections;
using System.Collections.Generic;

namespace _08._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
          int num = int.Parse(Console.ReadLine());
          Queue<string> queue = new Queue<string>();
          int count = 0;
          string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input != "green")
                {
                    queue.Enqueue(input);
                }

                if (input == "green")
                {
                    
                    for (int i = 0; i < num; i++)
                    {
                        if (queue.Count < 1)
                        {
                            continue;
                        }

                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        count++;
                    }
                }
               
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
     
        }
    }
}
