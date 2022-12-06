using Heroes.Models.Contracts;
using System;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }

                this.health = value;
            }
        }

        public int Armour
        {
            get { return this.armour; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }

                this.armour = value;
            }
        }
        
        public bool IsAlive => this.health > 0;
        //{
        //    get 
        //    {
        //        if (this.Health > 0)
        //        {
        //            return true;
        //        }

        //        return false;
        //    }
        //}

        public IWeapon Weapon
        {
            get { return this.weapon; }
            private set 
            {
                if (value is null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }

                this.weapon = value; 
            }
        }


        public void AddWeapon(IWeapon weapon)
        {
            if (this.Weapon is null)
            {
                this.Weapon = weapon;
            }
        }

        public void TakeDamage(int points)
        {
            this.Armour -= points;
            int pointsLeft = 0;

            if (this.Armour < 0)
            {
                pointsLeft = Math.Abs(this.Armour);
                this.Armour = 0;
            }

            if (pointsLeft > 0)
            {
                this.Health -= pointsLeft;
            }

            if (this.Health < 0)
            {
                this.Health = 0;
            }

        }
    }
}
