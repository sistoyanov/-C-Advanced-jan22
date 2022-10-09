using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> numbers = new EqualityScale<int>(6, 5);
            Console.WriteLine(numbers.AreEqual());

            EqualityScale<string> words = new EqualityScale<string>("yes", "yes");
            Console.WriteLine(words.AreEqual());
        }
    }
}
