using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList strings = new RandomList { "1", "2", "3", "4"};
            Console.WriteLine(strings.RandomString());
        }
    }
}
