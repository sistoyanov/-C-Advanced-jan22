
namespace Raiding.Models
{
    using Interfaces;
    public class Paladin : BaseHero, IHero
    {
        private const int POWER = 100;
        public Paladin(string name) : base(name)
        {
            this.Power = POWER;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
