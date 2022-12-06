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
            ICollection<IHero> barbarians = new List<IHero>();
            ICollection<IHero> knights = new List<IHero>();
            string output = string.Empty;

            knights = players.Where(h => h.GetType().Name == typeof(Knight).Name).ToList();
            barbarians = players.Where(h => h.GetType().Name == typeof(Barbarian).Name).ToList();

            while (knights.Any(k => k.IsAlive) && barbarians.Any(b => b.IsAlive))
            {
                foreach (Knight knight in knights)
                {
                    foreach (Barbarian barbarian in barbarians)
                    {
                        if (knight.IsAlive && barbarian.IsAlive)
                        {
                            barbarian.TakeDamage(knight.Weapon.DoDamage());
                        }
                    }
                }


                foreach (Barbarian barbarian in barbarians)
                {
                    foreach (Knight knight in knights)
                    {
                        if (barbarian.IsAlive && knight.IsAlive)
                        {
                            knight.TakeDamage(barbarian.Weapon.DoDamage());
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
