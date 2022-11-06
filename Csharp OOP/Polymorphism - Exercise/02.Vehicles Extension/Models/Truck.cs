namespace Vehicles.Models
{
    using System;
    using Vehicles.Exeptions;
    public class Truck : Vehicle
    {
        private const double AirConditionerConsuption = 1.6;
        private const double FuelLost = 0.95;
        private double fuelQantity;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelConsumption, tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity
        {
            get => this.fuelQantity;
            set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQantity = 0;
                }
                else
                {
                    this.fuelQantity = value;
                }


            }
        }

        public override double FuelConsumption { get ; set ; }

        public override double TankCapacity { get; set; }

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
            if (fuel <= 0)
            {
                throw new ArgumentException(string.Format(ExeptionMessages.InvalidFuelExeption));
            }

            double fuleCapacity = this.TankCapacity - this.FuelQuantity;

            if (fuleCapacity >= fuel)
            {
                this.FuelQuantity += fuel * FuelLost;
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
