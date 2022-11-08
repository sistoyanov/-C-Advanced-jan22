namespace WildFarm.Models.Animal{
    
    using System;
    using System.Collections.Generic;
    using WildFarm.Models.Food;
    public class Tiger : Feline
    {
        private const double TIGER_GAIN_INDEX = 1;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods => new HashSet<Type> { typeof(Meat)};

        protected override double GainIndex => TIGER_GAIN_INDEX;

        public override string ProduceSound()
        {
            return $"ROAR!!!";
        }
    }
}
