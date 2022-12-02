using System;
using System.Text.RegularExpressions;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double TunedCarFuelAvailable = 65;
        private const double TunedCarFuelConsumtpionPerRace = 7.5;
        public TunedCar(string make, string model, string vin, int horsePower) : base(make, model, vin, horsePower, TunedCarFuelAvailable, TunedCarFuelConsumtpionPerRace)
        {
        }

        public override void Drive()   /// validate if this works
        {
            base.Drive();
            this.HorsePower = (int)Math.Round(this.HorsePower * 0.97);
        }
    }
}
