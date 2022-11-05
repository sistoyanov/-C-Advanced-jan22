namespace Operations.IO
{
    using Iterfaces;
    using System;
    internal class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
 
    }
}
