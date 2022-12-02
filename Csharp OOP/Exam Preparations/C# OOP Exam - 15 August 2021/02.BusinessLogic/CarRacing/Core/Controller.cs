using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private readonly IRepository<ICar> cars;
        private readonly IRepository<IRacer> racers;
        private readonly IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string vin, int horsePower)
        {
            ICar carToAdd;

            if (type == "SuperCar")
            {
                carToAdd = new SuperCar(make, model, vin, horsePower);
            }
            else if (type == "TunedCar")
            {
                carToAdd = new TunedCar(make, model, vin, horsePower);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            this.cars.Add(carToAdd);
            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, vin);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar racerCar = this.cars.FindBy(carVIN);
            IRacer racerToAdd;

            if (racerCar is null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            if (type == "ProfessionalRacer")
            {
                racerToAdd = new ProfessionalRacer(username, racerCar);
            }
            else if (type == "StreetRacer")
            {
                racerToAdd = new StreetRacer(username, racerCar);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }


            this.racers.Add(racerToAdd);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = this.racers.FindBy(racerOneUsername);
            IRacer racerTwo = this.racers.FindBy(racerTwoUsername);

            if (racerOne is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            else if (racerTwo is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return this.map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();

            foreach (Racer racer in this.racers.Models.OrderByDescending(r => r.DrivingExperience).ThenBy(r => r.Username))
            {
                output.AppendLine(racer.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
