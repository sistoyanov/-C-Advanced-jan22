using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IPlanet>  planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planetToAdd = this.planets.FindByName(name);

            if (planetToAdd != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }
            else
            {
                planetToAdd = new Planet(name, budget);
                planets.AddItem(planetToAdd);

                return string.Format(OutputMessages.NewPlanet, name);
            }
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            IMilitaryUnit militaryUnit;

            if (planet is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName == "StormTroopers")
            {
                militaryUnit = new StormTroopers();
            }
            else if (unitTypeName == "SpaceForces")
            {
                militaryUnit = new SpaceForces();
            }
            else if (unitTypeName == "AnonymousImpactUnit")
            {
                militaryUnit = new AnonymousImpactUnit();
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            planet.Spend(militaryUnit.Cost);
            planet.AddUnit(militaryUnit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            IWeapon weapon;

            if (planet is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            if (planet.Weapons.Any(u => u.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);


            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (planet is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NoUnitsFound));
            }

            planet.Spend(1.25);
            planet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet first = this.planets.FindByName(planetOne);
            IPlanet second = this.planets.FindByName(planetTwo);

            string output = string.Empty;

            if (first.MilitaryPower > second.MilitaryPower)
            {
                first.Spend(first.Budget / 2);
                first.Profit(second.Budget / 2);
                first.Profit(second.Army.Sum(u => u.Cost) + second.Weapons.Sum(w => w.Price));

                this.planets.RemoveItem(planetTwo);
                output = string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }
            else if (second.MilitaryPower > first.MilitaryPower)
            {
                second.Spend(second.Budget / 2);
                second.Profit(first.Budget / 2);
                second.Profit(first.Army.Sum(u => u.Cost) + first.Weapons.Sum(w => w.Price));

                this.planets.RemoveItem(planetOne);
                output = string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }

            if (first.MilitaryPower == second.MilitaryPower)
            {
                bool firstHasNuclear = first.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");
                bool secondHasNuclear = second.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");

                if (firstHasNuclear && !secondHasNuclear)
                {
                    first.Spend(first.Budget / 2);
                    first.Profit(second.Budget / 2);
                    first.Profit(second.Army.Sum(u => u.Cost) + second.Weapons.Sum(w => w.Price));

                    this.planets.RemoveItem(planetTwo);
                    output = string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
                }
                else if (secondHasNuclear && !firstHasNuclear)
                {
                    second.Spend(second.Budget / 2);
                    second.Profit(first.Budget / 2);
                    second.Profit(first.Army.Sum(u => u.Cost) + first.Weapons.Sum(w => w.Price));

                    this.planets.RemoveItem(planetOne);
                    output = string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                }
                else if (firstHasNuclear && secondHasNuclear || !firstHasNuclear && !secondHasNuclear)
                {
                    first.Spend(first.Budget / 2);
                    second.Spend(second.Budget / 2);

                    output = string.Format(OutputMessages.NoWinner);
                }
            }

            return output;
        }

        public string ForcesReport()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (IPlanet planet in planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name))
            {
                output.AppendLine(planet.PlanetInfo());
            }

            return output.ToString().TrimEnd();
        }

    }


}

