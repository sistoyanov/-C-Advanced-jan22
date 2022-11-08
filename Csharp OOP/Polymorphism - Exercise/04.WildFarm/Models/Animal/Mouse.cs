namespace WildFarm.Models.Animal
{
    using System;
    using System.Collections.Generic;
    using Food;
    public class Mouse : Mammal
    {
        private const double MOUSE_GAIN_INDEX = 0.10;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods => new HashSet<Type> { typeof(Vegetable), typeof(Fruit)};

        protected override double GainIndex => MOUSE_GAIN_INDEX;

        public override string ProduceSound()
        {
            return $"Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
