using System;

namespace BoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Box<string> newBox = new Box<string>(Console.ReadLine());
                Console.WriteLine(newBox);
            }
        }
    }
}
