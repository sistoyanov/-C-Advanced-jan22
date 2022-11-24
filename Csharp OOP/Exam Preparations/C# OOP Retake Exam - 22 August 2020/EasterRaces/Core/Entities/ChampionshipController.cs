
namespace EasterRaces.Core.Entities
{
    using Contracts;
    using Models.Cars.Contracts;
    using Models.Cars.Entities;
    using Models.Drivers.Contracts;
    using Models.Drivers.Entities;
    using Models.Races.Contracts;
    using Repositories.Contracts;
    using Repositories.Entities;
    using Utilities.Messages;
    using System;
    using EasterRaces.Models.Races.Entities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> driverRepository;
        private readonly IRepository<ICar> carRepository;
        private readonly IRepository<IRace> raceRepository;
        private const int MIN_RACE_PARTICIPANTS = 3;
        public ChampionshipController()
        {
            this.driverRepository = new DriverRepository();
            this.carRepository = new CarRepository();
            this.raceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = driverRepository.GetByName(driverName);
            ICar car = carRepository.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = raceRepository.GetByName(raceName);
            IDriver driver = driverRepository.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar newCar;
            newCar = carRepository.GetByName(model);

            if (newCar != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            if (type == "Muscle")
            {
                newCar = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                newCar = new SportsCar(model, horsePower);
            }

            this.carRepository.Add(newCar);

            return string.Format(OutputMessages.CarCreated, newCar.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            Driver newDriver = new Driver(driverName);

            if (driverRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            this.driverRepository.Add(newDriver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            Race newRace = new Race(name, laps);

            if (raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            this.raceRepository.Add(newRace);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < MIN_RACE_PARTICIPANTS)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, MIN_RACE_PARTICIPANTS));
            }

            List<IDriver> allDrivers = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).ToList();

            IDriver first = allDrivers[0];
            IDriver second = allDrivers[1];
            IDriver third = allDrivers[2];

            StringBuilder output = new StringBuilder();
            output.AppendLine($"Driver {first.Name} wins {raceName} race.");
            output.AppendLine($"Driver {second.Name} is second in {raceName} race.");
            output.AppendLine($"Driver {third.Name} is third in {raceName} race.");

            return output.ToString().TrimEnd(); ;
        }
    }
}
