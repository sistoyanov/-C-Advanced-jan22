namespace WildFarm.Models.Animal
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WildFarm.Exceptions;

    public abstract class Animal : IAnimal
    {
        public Animal()
        {
            this.FoodEaten = 0;
        }
        protected Animal(string name, double weight) : this()
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected abstract double GainIndex { get; }

        public abstract IReadOnlyCollection<Type> PreferredFoods { get; }

        public virtual void Eat(IFood food)
        {
            if (!this.PreferredFoods.Any(t => food.GetType().Name == t.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidFood, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += food.Quantity * this.GainIndex;
            this.FoodEaten += food.Quantity;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }

    }
}
