namespace Raiding.Models
{
    using Interfaces;
    public class Rogue : BaseHero, IHero
    {
        private const int POWER = 80;
        public Rogue(string name) : base(name)
        {
            this.Power = POWER;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
