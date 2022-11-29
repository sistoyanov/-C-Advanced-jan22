using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
        private readonly List<Character> party;
        private readonly List<Item> items;
        Character character;
		Item item;

        public WarController()
        {
            this.party = new List<Character>();
            this.items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
		    string characterType = args[0];
			string characterName = args[1];


			if (characterType == "Warrior")
			{
				this.character= new Warrior(characterName);
			}
			else if (characterType == "Priest")
			{
				this.character = new Priest(characterName);
			}
			else
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));

            }

			this.party.Add(this.character);
			return string.Format(SuccessMessages.JoinParty, characterName);
        }

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

            if (itemName == "HealthPotion")
            {
				this.item = new HealthPotion();
            }
            else if (itemName == "FirePotion")
            {
				this.item = new FirePotion();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));

            }

			this.items.Add(this.item);
			return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];

			this.item = this.items.LastOrDefault();
			this.character = this.party.FirstOrDefault(c => c.Name == characterName);

			if (character is null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

			if (item is null)
			{
				throw new InvalidOperationException(string.Format(ExceptionMessages.ItemPoolEmpty));
            }

			this.items.Remove(this.item);
			this.character.Bag.AddItem(this.item);
			return string.Format(SuccessMessages.PickUpItem, characterName, this.item.GetType().Name);

        }

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			this.character = this.party.FirstOrDefault(c => c.Name == characterName);

			if (character is null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

			this.item = character.Bag.GetItem(itemName);
			this.character.UseItem(item);
			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

		public string GetStats()
		{
			StringBuilder output = new StringBuilder();

			foreach (var character in this.party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
			{
				output.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {(character.IsAlive ? "Alive" : "Dead")}");
            }

			return output.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			Character attacker = this.party.FirstOrDefault(c => c.Name == attackerName);
			Character receiver = this.party.FirstOrDefault(c => c.Name == receiverName);

			if (attacker is null)
			{
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            if (receiver is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

			if (attacker.GetType().Name != "Warrior")
			{
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            Warrior currentAttacker = attacker as Warrior;
			currentAttacker.Attack(receiver);

			StringBuilder output = new StringBuilder();
			output.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

			if (!receiver.IsAlive)
			{
				output.AppendLine($"{receiverName} is dead!");
			}

			return output.ToString().TrimEnd();
        }

		public string Heal(string[] args)
		{
            string healerName = args[0];
            string healingReceiverName  = args[1];

            Character healer = this.party.FirstOrDefault(c => c.Name == healerName);
            Character healingReceiver = this.party.FirstOrDefault(c => c.Name == healingReceiverName );

            if (healer is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

            if (healingReceiver is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName ));
            }

            if (healer.GetType().Name != "Priest")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

			Priest currentPriest = healer as Priest;
			currentPriest.Heal(healingReceiver);

			return $"{healerName} heals {healingReceiverName} for {healer.AbilityPoints}! {healingReceiverName} has {healingReceiver.Health} health now!";
        }
	}
}
