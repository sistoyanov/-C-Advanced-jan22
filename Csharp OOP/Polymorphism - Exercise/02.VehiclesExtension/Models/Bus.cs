namespace Vehicles.Models
{
    using System;
    using Exeptions;

    public class Bus : Vehicle
    {
        private const double BUS_AIRCONDITIONER_CONSUPTION = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity, BUS_AIRCONDITIONER_CONSUPTION)
        {
        }

        
    }
}
