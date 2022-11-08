namespace Vehicles
{
    using IO;
    using IO.Interfaces;
    using Core;
    using Core.Interafaces;
    using Factories;
    using Factories.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IVehicleFactory vehicleFactory = new VechicleFactory();

            IEngine engine = new Engine(reader, writer, vehicleFactory);
            engine.Run();
        }
    }
}
