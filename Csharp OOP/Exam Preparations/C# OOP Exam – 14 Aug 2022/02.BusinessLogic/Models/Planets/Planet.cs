using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private readonly IRepository<IMilitaryUnit> units;
        private readonly IRepository<IWeapon> weapons;
        private string name;
        private double budget;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.units = new UnitRepository();
            this.weapons = new WeaponRepository();
        }

        public string Name
        {
            get { return this.name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                this.name = value; 
            }
        }

        public double Budget
        {
            get { return this.budget; }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                this.budget = value; 
            }
        }

        public double MilitaryPower => CalculateMilitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit) => this.units.AddItem(unit);

        public void AddWeapon(IWeapon weapon) => this.weapons.AddItem(weapon);

        public void TrainArmy()
        {
            foreach (IMilitaryUnit unit in this.Army)
            {
                unit.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (this.Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            this.Budget -= amount;
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public string PlanetInfo()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Planet: {this.Name}")
                  .AppendLine($"--Budget: {this.Budget} billion QUID")
                  .AppendLine($"--Forces: {(this.Army.Count > 0 ? string.Join(", ", this.Army.Select(u => u.GetType().Name)) : "No units")}")
                  .AppendLine($"--Combat equipment: {(this.Weapons.Count > 0 ? string.Join(", ", this.Weapons.Select(u => u.GetType().Name)) : "No weapons")}")
                  .AppendLine($"--Military Power: {this.MilitaryPower}");

            return output.ToString().TrimEnd();
        }



        private double CalculateMilitaryPower()
        {
            double totalEnduranceLevel = this.units.Models.Sum(u => u.EnduranceLevel);
            double totalDestructionLevel = this.weapons.Models.Sum(w => w.DestructionLevel);
            double totalAmount = totalEnduranceLevel + totalDestructionLevel;

            if (this.Army.Any(u => u.GetType().Name == "AnonymousImpactUnit"))
            {
                totalAmount *= 0.30;
            }

            if (this.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
            {
                totalAmount *= 0.45;
            }

            return Math.Round(totalAmount, 3);
        }
    }
}
