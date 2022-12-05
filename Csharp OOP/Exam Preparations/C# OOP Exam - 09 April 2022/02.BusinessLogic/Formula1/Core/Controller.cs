using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IPilot> pilotRepository;
        private readonly IRepository<IRace> raceRepository ;
        private readonly IRepository<IFormulaOneCar> carRepository ;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }

        public string CreatePilot(string fullName)
        {
            IPilot newPilot = this.pilotRepository.FindByName(fullName);

            if (newPilot != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            else
            {
                newPilot = new Pilot(fullName);
                this.pilotRepository.Add(newPilot);
                return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
            }

        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar newCar = this.carRepository.FindByName(model);

            if (newCar != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            else
            {
                if (type == "Ferrari")
                {
                    newCar = new Ferrari(model, horsepower, engineDisplacement);
                }
                else if (type == "Williams")
                {
                    newCar = new Williams(model, horsepower, engineDisplacement);
                }
                else
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
                }

                this.carRepository.Add(newCar);
                return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
            }

        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace newRace = this.raceRepository.FindByName(raceName);

            if (newRace != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            else
            {
                newRace = new Race(raceName, numberOfLaps);
                this.raceRepository.Add(newRace);
                return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
            }

        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilotToReciveCar = this.pilotRepository.FindByName(pilotName);
            IFormulaOneCar carToAddToPilot = this.carRepository.FindByName(carModel);

            if (pilotToReciveCar is null || pilotToReciveCar.Car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            if (carToAddToPilot is null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilotToReciveCar.AddCar(carToAddToPilot);
            this.carRepository.Remove(carToAddToPilot);
            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, carToAddToPilot.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace raceToRecivePilot = this.raceRepository.FindByName(raceName);
            IPilot pilotToAddToRace = this.pilotRepository.FindByName(pilotFullName);

            if (raceToRecivePilot is null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (pilotToAddToRace is null || pilotToAddToRace.CanRace == false || raceToRecivePilot.Pilots.Contains(pilotToAddToRace))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            raceToRecivePilot.AddPilot(pilotToAddToRace);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string StartRace(string raceName)
        {
            IRace raceToStart = this.raceRepository.FindByName(raceName);

            if (raceToStart is null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (raceToStart.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (raceToStart.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            List<IPilot> racers = raceToStart.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(raceToStart.NumberOfLaps)).ToList();  /// validate this
            raceToStart.TookPlace = true;
            IPilot winner = racers[0];
            IPilot second = racers[1];
            IPilot third = racers[2];
            winner.WinRace();

            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format(OutputMessages.PilotFirstPlace, winner.FullName, raceName))
                  .AppendLine(string.Format(OutputMessages.PilotSecondPlace, second.FullName, raceName))
                  .AppendLine(string.Format(OutputMessages.PilotThirdPlace, third.FullName, raceName));

            return output.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder output = new StringBuilder();

            foreach (IRace race in this.raceRepository.Models.Where(r => r.TookPlace))
            {
                output.AppendLine(race.RaceInfo());
            }

            return output.ToString().TrimEnd();
        }


        public string PilotReport()
        {
            StringBuilder output = new StringBuilder();

            foreach (IPilot pilot in this.pilotRepository.Models.OrderByDescending(p => p.NumberOfWins))
            {
                output.AppendLine(pilot.ToString());
            }

            return output.ToString().TrimEnd();
        }


    }
}
