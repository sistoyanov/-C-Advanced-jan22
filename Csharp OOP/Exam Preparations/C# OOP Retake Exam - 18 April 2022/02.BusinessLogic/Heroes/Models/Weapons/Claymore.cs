using static System.Net.Mime.MediaTypeNames;

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
            if (this.Durability == 0)
            {
                return 0;
            }
            else
            {
                this.Durability--;
            }

            return ClaymoreDamage;

        }
    }
}
