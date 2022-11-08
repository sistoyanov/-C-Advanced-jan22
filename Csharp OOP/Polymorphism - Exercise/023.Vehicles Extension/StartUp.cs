namespace Vehicles
{
    using IO;
    using IO.Interfaces;
    using Vehicles.Core;
    using Vehicles.Core.Interafaces;

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
