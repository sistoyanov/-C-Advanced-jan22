namespace WildFarm.Models.Animal
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Models.Food;
    public class Cat : Feline
    {
        private const double CAT_GAIN_INDEX = 0.3;
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods => new HashSet<Type> { typeof(Vegetable), typeof(Meat)};

        protected override double GainIndex => CAT_GAIN_INDEX;

        public override string ProduceSound()
        {
            return $"Meow";
        }
    }
}
