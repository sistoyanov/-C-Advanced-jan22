
namespace EasterRaces.Models.Races.Entities
{
    using Drivers.Contracts;
    using EasterRaces.Utilities.Messages;
    using Races.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Race : IRace
    {
        private const int RACE_REQUIRED_SYMBOLS = 5;
        private const int MIN_LAPS = 1;

        private string name;
        private int laps;
        private ICollection<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new HashSet<IDriver>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Count() < RACE_REQUIRED_SYMBOLS)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, RACE_REQUIRED_SYMBOLS));
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get { return this.laps; }
            private set
            {
                if (value < MIN_LAPS)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, MIN_LAPS));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers as IReadOnlyCollection<IDriver>;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverInvalid));
            }

            if (!driver.CanParticipate) // chaeck if this work
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (this.drivers.Contains(driver))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            drivers.Add(driver);
        }

    }
}
