
namespace WarCroft.Entities.Characters
{
    using System;
    using Constants;
    using Entities.Characters.Contracts;
    using Entities.Inventory;

    public class Warrior : Character, IAttacker
    {
        private const double WarriorBaseHealth = 100;
        private const double WarriorBaseArmor = 50;
        private const double WarriorAbilityPoints = 40;

        public Warrior(string name) : base(name, WarriorBaseHealth, WarriorBaseArmor, WarriorAbilityPoints, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {

                if (this.Name == character.Name)
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.CharacterAttacksSelf));
                }

                character.TakeDamage(this.AbilityPoints);

            }
        }
    }
}
