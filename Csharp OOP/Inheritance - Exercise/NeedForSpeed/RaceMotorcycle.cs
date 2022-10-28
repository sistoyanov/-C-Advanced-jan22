using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double RACE_MOTORCYCLE_FUEL_CONSUMPRION = 8;
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
          
        }

        public override double FuelConsumption => RACE_MOTORCYCLE_FUEL_CONSUMPRION;
    }
}
