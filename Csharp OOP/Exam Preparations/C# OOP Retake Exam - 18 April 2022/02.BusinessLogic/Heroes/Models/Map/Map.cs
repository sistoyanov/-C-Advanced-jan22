using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            ICollection<Barbarian> barbarians = new List<Barbarian>();
            ICollection<Knight> knights = new List<Knight>();
            string output = string.Empty;

            foreach (IHero hero in players)
            {
                if (hero.GetType().Name == "Barbarian")
                {
                    barbarians.Add(hero as Barbarian);
                }
                else if (hero.GetType().Name == "Knight")
                {
                    knights.Add(hero as Knight);
                }
            }

            while (knights.Any(k => k.IsAlive) && barbarians.Any(b => b.IsAlive))
            {
                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {

                        foreach (var barberian in barbarians)
                        {
                            barberian.TakeDamage(knight.Weapon.DoDamage());
                        }

                    }

                }


                foreach (var barberian in barbarians)
                {
                    if (barberian.IsAlive)
                    {

                        foreach (var knight in knights)
                        {
                            knight.TakeDamage(barberian.Weapon.DoDamage());
                        }

                    }

                }

            }


            if (knights.Count(k => k.IsAlive) > 0)
            {
                output = $"The knights took {knights.Count(k => !k.IsAlive)} casualties but won the battle.";
            }
            else if (barbarians.Count(b => b.IsAlive) > 0)
            {
                output = $"The barbarians took {barbarians.Count(b => !b.IsAlive)} casualties but won the battle.";
            }

            return output;
        }
    }
}
