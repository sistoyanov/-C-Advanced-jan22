using System;
using System.Collections.Generic;
using System.Linq;

namespace SwapMethodIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();

            for (int i = 0; i < count; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box.Value.Add(input);
            }

            int[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            box.Swap(indexes[0], indexes[1]);
            Console.WriteLine(box);

        }
    }
}
