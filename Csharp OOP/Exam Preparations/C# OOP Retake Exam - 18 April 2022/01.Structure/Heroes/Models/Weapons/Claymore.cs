namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        public const int ClaymoreDamage = 20;
        public Claymore(string name, int durability) : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            this.Durability -= 1;

            if (this.Durability == 0) /// only =
            {
                return 0;
            }
            else
            {
                return ClaymoreDamage;
            }

        }
    }
}
