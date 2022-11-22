
namespace EasterRaces.Models.Cars.Entities
{
    using Models.Cars.Contracts;
    using Utilities.Messages;
    using System;
    using System.Linq;
    public abstract class Car : ICar
    {
        private const int CAR_REQUIRED_SYMBOLS = 4;
        private string model;
        private int horsePower;
        //private double cubicCentimeters;
        private int minHorsePower;
        private int maxHorsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Count() < CAR_REQUIRED_SYMBOLS)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, CAR_REQUIRED_SYMBOLS));
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get { return this.horsePower; }
            private set
            {
                if (value < this.minHorsePower || value > this.maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; private set; }
        //{ 
        //    get { return this.cubicCentimeters; }
        //    private set { this.cubicCentimeters = value; }
        //}

        public double CalculateRacePoints(int laps) => this.CubicCentimeters / this.HorsePower * laps;

    }


}
