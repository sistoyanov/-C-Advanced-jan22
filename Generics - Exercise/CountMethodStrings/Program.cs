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
            List<Box<string>> boxList = new List<Box<string>>();

            for (int i = 0; i < count; i++)
            {
                Box<string> newBox = new Box<string>(Console.ReadLine());
                boxList.Add(newBox);
            }

            string comperer = Console.ReadLine();
            Console.WriteLine(CountComparable(boxList, comperer));
        }

        public static int CountComparable<T>(List<T> boxList, string comperer)
        {
            int counter = 0;

            foreach (T box in boxList)
            {
                int result = string.Compare(box.ToString(), comperer);

                if (result > 0)
                {
                    counter++;
                }

            }

            return counter;
        }
    }
}
