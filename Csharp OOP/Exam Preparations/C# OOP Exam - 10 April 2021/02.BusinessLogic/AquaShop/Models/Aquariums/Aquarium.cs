using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        //private int comfort;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fishes;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fishes = new List<IFish>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidAquariumName));
                }

                this.name = value;
            }
        }

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public int Comfort => this.decorations.Sum(d => d.Comfort); /// Validate this
        //{
        //    get { return comfort; }
        //    private set { comfort = value; }
        //}

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fishes;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Capacity <= this.Fish.Count)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotEnoughCapacity));
            }

            this.fishes.Add(fish);
        }

        public void Feed()
        {
            foreach (IFish fish in this.fishes)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"{this.Name} ({this.GetType().Name}):");

            if (this.Fish.Count > 0)
            {
                output.AppendLine($"Fish: {string.Join(", ", this.Fish.Select(f => f.Name))}");
            }
            else
            {
                output.AppendLine("Fish: none");
            }

            output.AppendLine($"Decorations: {this.Decorations.Count}");
            output.AppendLine($"Comfort: {this.Comfort}");

            return output.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish) => this.fishes.Remove(fish); ///??? Validate this
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
