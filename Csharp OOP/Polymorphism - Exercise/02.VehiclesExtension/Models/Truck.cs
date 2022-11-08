namespace Vehicles.Models
{
    using System;
    using Vehicles.Exeptions;
    public class Truck : Vehicle
    {
        private const double TRUCK_AIRCONDITIONER_CONSUPTION = 1.6;
        private const double FUEL_LOST = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity, TRUCK_AIRCONDITIONER_CONSUPTION)
        {
        }

        public override void Refuel(double fuel)
        {

            double fuleCapacity = this.TankCapacity - this.FuelQuantity;

            if (fuleCapacity >= fuel)
            {
                base.Refuel(fuel * FUEL_LOST);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExeptionMessages.NoCapacityFuelExeption, fuel));
            }

            
        }

    }
}
