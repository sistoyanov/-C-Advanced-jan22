
namespace EasterRaces.Models.Drivers.Entities
{
    using Cars.Contracts;
    using Drivers.Contracts;
    using EasterRaces.Utilities.Messages;
    using System;
    using System.Linq;

    public class Driver : IDriver
    {
        private const int DRIVER_REQUIRED_SYMBOLS = 5;
        private string name;
        private ICar car;
        private int numberOfWins;
        //private bool canParticipate = false;

        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Count() < DRIVER_REQUIRED_SYMBOLS)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, DRIVER_REQUIRED_SYMBOLS));
                }

                this.name = value;
            }
        }
        public ICar Car { get; private set; }

        public int NumberOfWins => this.numberOfWins;

        public bool CanParticipate
        {
            get
            {
                if (this.Car == null)
                {
                    return false;
                }

                return true;
            }
        }

        public void AddCar(ICar car)
        {

            if (car == null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.CarInvalid));
            }

            this.Car = car;
        }

        public void WinRace() => this.numberOfWins++;

    }


}
