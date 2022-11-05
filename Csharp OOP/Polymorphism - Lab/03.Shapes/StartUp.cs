namespace Shapes
{
    using Shapes.Core.Interafaces;
    using Shapes.IO;
    using Shapes.IO.Interfaces;
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
