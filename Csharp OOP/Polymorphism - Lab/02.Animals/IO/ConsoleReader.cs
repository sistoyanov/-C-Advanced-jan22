namespace Animals.IO
{
    using System;
    using Interfaces;
    public class ConsoleReader : IReader
    {
        public void ReadLine(string text) => Console.ReadLine();

    }
}
