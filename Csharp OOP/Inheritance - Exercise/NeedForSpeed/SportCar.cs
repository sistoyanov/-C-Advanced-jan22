using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double SPORT_CAR_FUEL_CONSUPTION = 10;
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
          
        }

        public override double FuelConsumption => SPORT_CAR_FUEL_CONSUPTION;
    }
}
