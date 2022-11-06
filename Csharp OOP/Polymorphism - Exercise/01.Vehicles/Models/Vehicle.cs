using System;

namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public abstract double FuelQuantity { get; set; }
        public abstract double FuelConsumption { get; set; }

        public abstract string Drive(double distance);

        public abstract void Refuel(double fuel);

    }
}
