using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pumpNum = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < pumpNum; i++)
            {
                int[] currentPump = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumps.Enqueue(currentPump);
            }

            int inumber = 0;

            while (true)
            {
                int totalLiters = 0;
                bool isComplete = true;

                foreach (var item in pumps)
                {
                    int litters = item[0];
                    int distance = item[1];

                    totalLiters += litters;

                    if (totalLiters - distance < 0)
                    {
                        inumber++;
                        int[] currentPump = pumps.Dequeue();
                        pumps.Enqueue(currentPump);
                        isComplete = false;
                        break;
                    }

                    totalLiters -= distance;
                }

                if (isComplete)
                {
                    break;
                }
                
            }

            Console.WriteLine(inumber);
        }
    }
}
