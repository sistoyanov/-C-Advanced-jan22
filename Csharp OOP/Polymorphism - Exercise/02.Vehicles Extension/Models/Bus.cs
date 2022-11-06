namespace Vehicles.Models
{
    using System;
    using Exeptions;

    public class Bus : Vehicle
    {
        private double fuelQuantity;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelConsumption, tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
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

        public override double FuelConsumption { get ; set ; }

        public override double TankCapacity { get ; set ; }

        public override string Drive(double distance)
        {
            double neededFuel = distance * (this.FuelConsumption);

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
