using System;
using System.Collections.Generic;
using System.Linq;

namespace SwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                box.Value.Add(input);
            }

            int[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            box.Swap(indexes[0], indexes[1]);
            Console.WriteLine(box);

        }

    }
}
