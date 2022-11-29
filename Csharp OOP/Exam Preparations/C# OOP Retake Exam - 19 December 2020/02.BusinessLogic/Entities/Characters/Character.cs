
namespace WarCroft.Entities.Characters.Contracts
{
    using System;
    
    using WarCroft.Constants;
	using WarCroft.Entities.Inventory;
	using WarCroft.Entities.Items;

	public abstract class Character
    {
		// TODO: Implement the rest of the class.
		private string name;
		private double health;
		private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, IBag bag)
		{
			this.Name = name;
			this.BaseHealth = health;
			this.Health = this.BaseHealth;
			this.BaseArmor = armor;
			this.Armor = this.BaseArmor;
			this.AbilityPoints = abilityPoints;
			this.Bag = bag;
		}

		public string Name 
		{ 
			get
			{
				return this.name;
			}
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(string.Format(ExceptionMessages.CharacterNameInvalid));
                }

				this.name = value;
			}
		}

		public double BaseHealth { get;private set; }

		public double Health  
		{ 
			get
			{
				return this.health;
			}
			set
			{
				if (value > this.BaseHealth)
				{
					value = this.BaseHealth;
				}
				else if (value < 0)
				{
					value = 0;
				}
				
				this.health = value;
			} 
		}

		public double BaseArmor { get; private set; }

	    public double Armor 
		{ 
			get
			{
				return this.armor;
			} 
			private set
			{
				if (value < 0)
				{
					value = 0;
				}

				this.armor = value;
			}
		}

		public double AbilityPoints { get; private set; }

		public IBag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

		public void TakeDamage(double hitPoints)
		{
			this.EnsureAlive();

		    double hitPointsLeft = hitPoints - this.Armor;
			this.Armor -= hitPoints;

			if (hitPointsLeft > 0)
			{
				this.Health -= hitPointsLeft;
			}

			if (this.Health == 0)
			{
				this.IsAlive = false;
			}
		}

		public void UseItem(Item item)
		{
            this.EnsureAlive();
			item.AffectCharacter(this);
        }

        protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}