
namespace Vehicles.Core
{
    using System;
    using System.Linq;
    using Interafaces;
    using Vehicles.IO.Interfaces;
    using Vehicles.Models;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] carDetails = this.reader.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(carDetails[1]), double.Parse(carDetails[2]));
            string[] truckDetails = this.reader.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new Truck(double.Parse(truckDetails[1]), double.Parse(truckDetails[2]));

            int num = int.Parse(this.reader.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] vehicleDetails = this.reader.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
                string command = vehicleDetails[0];
                string vhicaleType = vehicleDetails[1];

                try
                {
                    if (command == "Drive")
                    {
                        double distance = double.Parse(vehicleDetails[2]);

                        if (vhicaleType == "Car")
                        {
                            this.writer.WriteLine(car.Drive(distance));
                            
                        }
                        else if (vhicaleType == "Truck")
                        {
                            this.writer.WriteLine(truck.Drive(distance));
                        }
                    }
                    else if (command == "Refuel")
                    {
                        double fuel = double.Parse(vehicleDetails[2]);

                        if (vhicaleType == "Car")
                        {
                            car.Refuel(fuel);
                        }
                        else if (vhicaleType == "Truck")
                        {
                            truck.Refuel(fuel);
                        }
                    }
                }
                catch (InvalidOperationException ioe)
                {

                    this.writer.WriteLine(ioe.Message);
                }
            }

            this.writer.WriteLine(car.ToString());
            this.writer.WriteLine(truck.ToString());
        }
    }
}
