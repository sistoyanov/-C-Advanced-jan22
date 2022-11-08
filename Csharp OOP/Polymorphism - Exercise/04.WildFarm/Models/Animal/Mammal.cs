namespace WildFarm.Models.Animal
{
    using WildFarm.Models.Interfaces;
    public abstract class Mammal : Animal, IMammal
    {
        public Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }
}
}
