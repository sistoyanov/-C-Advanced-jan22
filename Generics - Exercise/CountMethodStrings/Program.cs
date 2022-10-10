using System;
using System.Collections.Generic;
using System.Linq;

namespace CountMethodStrings
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

            string itemToCompare = Console.ReadLine();

            Console.WriteLine(box.Count(itemToCompare));
        }
    }
}
