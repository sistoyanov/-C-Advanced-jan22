namespace Raiding.Models
{
    using Interfaces;
    public class Rogue : BaseHero
    {
        private const int ROUGE_POWER = 80;
        public Rogue(string name) : base(name, ROUGE_POWER)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
