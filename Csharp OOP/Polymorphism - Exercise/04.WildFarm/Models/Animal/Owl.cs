
namespace WildFarm.Models.Animal
{
    using System;
    using System.Collections.Generic;
    using Food;
    public class Owl : Bird
    {
        private const double OWL_GAIN_INDEX = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods =>  new HashSet<Type> { typeof(Meat) };

        protected override double GainIndex => OWL_GAIN_INDEX;

        public override string ProduceSound()
        {
            return $"Hoot Hoot";
        }
    }
}
