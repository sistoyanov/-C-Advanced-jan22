using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private ICollection<string> targets;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            this.targets = new List<string>();
        }

        public string Name
        {
            get { return this.name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }

                this.name = value; 
            }
        }

        public ICaptain Captain
        {
            get { return this.captain; }
            set 
            {
                if (value is null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }

                this.captain = value; 
            }
        }

        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets => this.targets;

        public void Attack(IVessel target)
        {
            if (target is null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;

            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }

            this.Targets.Add(target.Name);
            this.captain.IncreaseCombatExperience();
            target.Captain.IncreaseCombatExperience();
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"- {this.Name}")
                  .AppendLine($" *Type: {this.GetType().Name}")
                  .AppendLine($" *Armor thickness: {this.ArmorThickness}")
                  .AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}")
                  .AppendLine($" *Speed: {this.Speed} knots")
                  .AppendLine($" *Targets: {(this.Targets.Count > 0 ? string.Join(", ", this.Targets) : "None")}");

            return output.ToString().TrimEnd();
        }

    }
}
