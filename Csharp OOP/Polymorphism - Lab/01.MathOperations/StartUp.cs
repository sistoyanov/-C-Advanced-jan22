namespace Operations
{
    using System;
    using IO.Iterfaces;
    using IO;
    using Operations.Core.Iterfaces;
    using Core;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
