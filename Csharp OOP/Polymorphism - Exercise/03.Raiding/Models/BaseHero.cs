namespace Raiding.Models
{
    using Interfaces;
    public abstract class BaseHero : IHero
    {
        public BaseHero(string name)
        {
            this.Name = name;
        }

        public string Name { get; set;  }

        public int Power { get; set; }

        public abstract string CastAbility();

    }
}
