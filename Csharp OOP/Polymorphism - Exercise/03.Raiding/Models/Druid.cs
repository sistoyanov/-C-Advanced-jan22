
namespace Raiding.Models
{
    using Interfaces;
    using System;
    using System.Linq;

    public class Druid : BaseHero, IHero
    {
        private const int POWER = 80;
        public Druid(string name) : base(name)
        {
            this.Power = POWER;
        }


        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
