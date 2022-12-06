﻿namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        public const int MaceDamage = 25;
        public Mace(string name, int durability) : base(name, durability)
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
                return MaceDamage;
            }

        }
    }
}
