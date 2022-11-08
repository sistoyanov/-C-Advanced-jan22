namespace Vehicles.Models
{
    using System;
    using Vehicles.Exeptions;
    public class Car : Vehicle
    {
        private const double CAR_AIRCONDITIONER_CONSUPTION = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption, CAR_AIRCONDITIONER_CONSUPTION)
        {
        }
    }
}
