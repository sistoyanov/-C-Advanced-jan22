using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IAstronaut> astronauts;
        private readonly IRepository<IPlanet> planets;
        private int exploredPlanetsCount = 0;

        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronautToAdd;

            if (type == "Biologist")
            {
                astronautToAdd = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronautToAdd = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronautToAdd = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            this.astronauts.Add(astronautToAdd);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);

        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planetToAdd = new Planet(planetName);

            foreach (var item in items)
            {
                planetToAdd.Items.Add(item);
            }
            
            planets.Add(planetToAdd);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronautToRemove = this.astronauts.FindByName(astronautName);

            if (astronautToRemove is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.astronauts.Remove(astronautToRemove);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            IMission mission = new Mission();
            IPlanet planetToExplore = this.planets.FindByName(planetName);
            ICollection<IAstronaut> astronautsToExplore = this.astronauts.Models.Where(a => a.Oxygen > 60).ToList();

            if (astronautsToExplore.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            mission.Explore(planetToExplore, astronautsToExplore);
            exploredPlanetsCount ++;
            int deadAstronauts = astronautsToExplore.Count(a => !a.CanBreath);

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{exploredPlanetsCount} planets were explored!")
                  .AppendLine("Astronauts info:");

            foreach(IAstronaut astronaut in this.astronauts.Models)
            {
                output.AppendLine(astronaut.ToString());
            }

            return output.ToString().TrimEnd();
        }

    }
}
