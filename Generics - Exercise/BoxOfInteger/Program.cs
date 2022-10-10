using System;

namespace BoxOfInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Box<int> newBox = new Box<int>(int.Parse(Console.ReadLine()));
                Console.WriteLine(newBox);
            }
        }
    }
}
