using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private double CAR_FUEL_CONSUPTION = 3;
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
          
        }

        public override double FuelConsumption => CAR_FUEL_CONSUPTION;
    }
}
