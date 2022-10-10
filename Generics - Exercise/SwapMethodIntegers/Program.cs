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
            List<Box<int>> boxList = new List<Box<int>>();

            for (int i = 0; i < count; i++)
            {
                Box<int> newBox = new Box<int>(int.Parse(Console.ReadLine()));
                boxList.Add(newBox);
            }

            int[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            boxList = Swap(boxList, indexes[0], indexes[1]);

            foreach (var box in boxList)
            {
                Console.WriteLine(box);
            }
        }

        public static List<T> Swap<T>(List<T> boxList, int currentIdx, int newIdx)
        {
            T oldValue = boxList[currentIdx];
            boxList[currentIdx] = boxList[newIdx];
            boxList[newIdx] = oldValue;

            return boxList;
        }
    
    }
}
