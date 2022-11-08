namespace Vehicles.Factories
{
    using Interfaces;
    using System;
    using Vehicles.Exeptions;
    using Vehicles.Models;
    using Vehicles.Models.Interfaces;
    public class VechicleFactory : IVehicleFactory
    {
        public VechicleFactory()
        {

        }

        public IVehicle CreateVehicle(string input)
        {
            IVehicle vehicle;
            string[] vehicleDetails = input.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);

            string vehicaleType = vehicleDetails[0];
            double fuelQty = double.Parse(vehicleDetails[1]);
            double fuelConsuption = double.Parse(vehicleDetails[2]);

            if (vehicaleType == "Car")
            {
                vehicle = new Car(fuelQty, fuelConsuption);
            }
            else if (vehicaleType == "Truck")
            {
                vehicle = new Truck(fuelQty, fuelConsuption);
            }
            else
            {
                throw new ArgumentException(string.Format(ExeptionMessages.IvalidVehicleType));
            }

            return vehicle;
        }

    }
}
