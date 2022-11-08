namespace Vehicles.Models
{
    using System;
    public abstract class Vehicle
    {
        public Vehicle(double fuelConsumption, double tankCapacity)
        {

            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public abstract double FuelConsumption { get; set; }

        public abstract double TankCapacity { get; set; }

        public abstract string Drive(double distance);

        public abstract void Refuel(double fuel);

    }
}
