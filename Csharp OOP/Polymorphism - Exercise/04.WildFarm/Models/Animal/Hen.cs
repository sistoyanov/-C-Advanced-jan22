
namespace WildFarm.Models.Animal
{
    using System;
    using System.Collections.Generic;
    using Food;
    internal class Hen : Bird
    {
        private const double HEN_GAIN_INDEX = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods => new HashSet<Type> { typeof(Fruit), typeof(Meat), typeof(Seeds), typeof(Vegetable)};

        protected override double GainIndex => HEN_GAIN_INDEX;

        public override string ProduceSound()
        {
            return $"Cluck";
        }
    }
}
