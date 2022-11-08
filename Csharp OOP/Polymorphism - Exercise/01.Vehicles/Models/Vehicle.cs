namespace Vehicles.Models
{
    using System;
    using Exeptions;
    using Interfaces;

    public abstract class Vehicle : IVehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption, double airConditionerConsuption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption + airConditionerConsuption;
        }

        public  double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public string Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;

            if (neededFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= neededFuel;
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExeptionMessages.InsufficientFuelExeption, this.GetType().Name));
            }

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
