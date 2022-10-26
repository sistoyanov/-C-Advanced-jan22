using System;
using System.Collections;
using System.Collections.Generic;

namespace _05._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt32);
            Queue<int> evenNums = new Queue<int>();
            

            foreach (var item in numbers)
            {
                if (item % 2 == 0)
                {
                    evenNums.Enqueue(item);
                }
            }

            List<int> output = new List<int>();

            while (evenNums.Count > 0)
            {
                output.Add(evenNums.Dequeue());
            }

            Console.WriteLine(string.Join(", ",output));

        }
    }
}
