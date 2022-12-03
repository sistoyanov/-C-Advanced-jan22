using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private ICollection<IEquipment> equipment;
        private ICollection<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.equipment = new List<IEquipment>();
            this.athletes = new List<IAthlete>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public ICollection<IEquipment> Equipment => this.equipment;

        public ICollection<IAthlete> Athletes => this.athletes;

        public double EquipmentWeight => this.equipment.Sum(e => e.Weight);

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Capacity <= this.athletes.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            this.athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete) => this.athletes.Remove(athlete);

        public void AddEquipment(IEquipment equipment) => this.equipment.Add(equipment);

        public void Exercise()
        {
            foreach (IAthlete athlete in this.athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{this.Name} is a {this.GetType().Name}:")
                  .AppendLine($"{(this.athletes.Count > 0 ? string.Join(", ", this.athletes.Select(a => a.FullName)) : "No athletes")}")
                  .AppendLine($"Equipment total count: {this.Equipment.Count}")
                  .AppendLine($"Equipment total weight: {this.EquipmentWeight} grams");

            return output.ToString().TrimEnd();
        }

    }
}
