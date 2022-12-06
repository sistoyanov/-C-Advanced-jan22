using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> models;

        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.models as IReadOnlyCollection<IWeapon>;

        public void Add(IWeapon model) => this.models.Add(model);

        public bool Remove(IWeapon model) => this.models.Remove(model);

        public IWeapon FindByName(string name) => this.models.FirstOrDefault(m => m.Name == name);
    }
}
