namespace WildFarm.Models.Animal
{
    using System;
    using System.Collections.Generic;
    using Food;
    public class Dog : Mammal
    {
        private const double DOG_GAIN_INDEX = 0.4;
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods => new HashSet<Type> { typeof(Meat)};

        protected override double GainIndex => DOG_GAIN_INDEX;

        public override string ProduceSound()
        {
            return $"Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
