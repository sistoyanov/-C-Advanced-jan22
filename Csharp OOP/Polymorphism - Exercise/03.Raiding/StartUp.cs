namespace Raiding
{
    using System;
    using IO;
    using IO.Interfaces;
    using Raiding.Core;
    using Raiding.Core.Interfaces;

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
