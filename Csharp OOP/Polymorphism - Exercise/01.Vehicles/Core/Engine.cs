
namespace Vehicles.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interafaces;
    using Vehicles.Factories.Interfaces;
    using Vehicles.IO.Interfaces;
    using Vehicles.Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        private IVehicle car;
        private IVehicle truck;
        private ICollection<IVehicle> vehicles;

        public Engine()
        {
            this.vehicles = new HashSet<IVehicle>();
        }

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory) : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }

        public void Run()
        {

            car = vehicleFactory.CreateVehicle(this.reader.ReadLine());
            truck = vehicleFactory.CreateVehicle(this.reader.ReadLine());

            vehicles.Add(car);
            vehicles.Add(truck);

            int num = int.Parse(this.reader.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] inputDetails = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    ProcessVehicle(inputDetails);

                }
                catch (InvalidOperationException ioe)
                {

                    this.writer.WriteLine(ioe.Message);
                }
            }

            PrintVehicles();

        }

        private void ProcessVehicle(string[] inputDetails)
        {
            string command = inputDetails[0];
            string vehicaleType = inputDetails[1];
            IVehicle currentVehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicaleType);

            if (command == "Drive")
            {
                double distance = double.Parse(inputDetails[2]);
                DriveVehicle(currentVehicle, distance);

            }
            else if (command == "Refuel")
            {
                double fuel = double.Parse(inputDetails[2]);
                RefuelVheicle(currentVehicle, fuel);

            }
        }

        private void DriveVehicle(IVehicle vehicle, double distance)
        {

           this.writer.WriteLine(vehicle.Drive(distance));
            
        }

        private void RefuelVheicle(IVehicle vehicle, double fuel)
        {
            vehicle.Refuel(fuel);
        }

        private void PrintVehicles()
        {
            foreach (IVehicle vehicle in vehicles)
            {
                this.writer.WriteLine(vehicle.ToString());
            }
        }
    }

}
