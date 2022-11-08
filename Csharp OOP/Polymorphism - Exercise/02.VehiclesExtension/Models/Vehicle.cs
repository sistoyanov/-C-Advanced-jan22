namespace Vehicles.Models
{
    using System;
    using Exeptions;
    using Interfaces;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double airConditionerConsuption)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption + airConditionerConsuption;
            
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }


            }
        }

        public double FuelConsumption { get; set; }

        public double TankCapacity { get; private set; }

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

            if (fuel <= 0)
            {
                throw new ArgumentException(string.Format(ExeptionMessages.InvalidFuelExeption));
            }

            double fuleCapacity = this.TankCapacity - this.FuelQuantity;

            if (fuleCapacity >= fuel)
            {
                this.FuelQuantity += fuel;
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExeptionMessages.NoCapacityFuelExeption, fuel));
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
