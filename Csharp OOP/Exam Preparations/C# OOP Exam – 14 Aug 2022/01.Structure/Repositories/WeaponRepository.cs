
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> models;

        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.models as IReadOnlyCollection<IWeapon>;

        public void AddItem(IWeapon model) => this.models.Add(model);

        public IWeapon FindByName(string weaponTypeName) => this.models.FirstOrDefault(m => m.GetType().Name == weaponTypeName);

        public bool RemoveItem(string weaponTypeName) => this.models.Remove(this.models.FirstOrDefault(m => m.GetType().Name == weaponTypeName));

    }
}
