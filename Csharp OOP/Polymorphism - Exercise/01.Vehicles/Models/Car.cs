using System;
using Vehicles.Exeptions;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AirConditionerConsuption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public override double FuelQuantity { get; set ; }
        public override double FuelConsumption { get ; set ; }

        public override string Drive(double distance)
        {
            double neededFuel = distance * (this.FuelConsumption + AirConditionerConsuption);

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

        public override void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
