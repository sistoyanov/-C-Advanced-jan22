using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IHero> heroes;
        private readonly IRepository<IWeapon> weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero heroToAdd = this.heroes.FindByName(name);
            string output = string.Empty;

            if (heroToAdd != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            if (type == "Barbarian")
            {
                heroToAdd = new Barbarian(name, health, armour);
                output = $"Successfully added Barbarian {name} to the collection.";
            }
            else if (type == "Knight")
            {
                heroToAdd = new Knight(name, health, armour);
                output = $"Successfully added Sir {name} to the collection.";
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            this.heroes.Add(heroToAdd);
            return output;
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weaponToAdd = this.weapons.FindByName(name);

            if (weaponToAdd != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            if (type == "Claymore")
            {
                weaponToAdd = new Claymore(name, durability);
            }
            else if (type == "Mace")
            {
                weaponToAdd = new Mace(name, durability);
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            this.weapons.Add(weaponToAdd);
            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero heroToRevive = this.heroes.FindByName(heroName);
            IWeapon weaponForHero = this.weapons.FindByName(weaponName);

            if (heroToRevive == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }

            if (weaponForHero == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            if (heroToRevive.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            heroToRevive.AddWeapon(weaponForHero);
            this.weapons.Remove(weaponForHero);
            return $"Hero {heroName} can participate in battle using a {weaponForHero.GetType().Name.ToLower()}.";
        }

        public string StartBattle()
        {
            Map map = new Map();
            ICollection<IHero> heroesForBattle = this.heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToList();
            return map.Fight(heroesForBattle);
        }

        public string HeroReport()
        {
            StringBuilder output = new StringBuilder();

            foreach (IHero hero in this.heroes.Models.OrderBy(m => m.GetType().Name).ThenByDescending(m => m.Health).ThenBy(m => m.Name))
            {
                output.AppendLine($"{hero.GetType().Name}: {hero.Name}")
                      .AppendLine($"--Health: {hero.Health}")
                      .AppendLine($"--Armour: {hero.Armour}")
                      .AppendLine($"--Weapon: {(hero.Weapon != null ? $"{hero.Weapon.Name}" : "Unarmed")}");
            }

            return output.ToString().TrimEnd();
        }

    }
}
