using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly ICollection<IMilitaryUnit> models;

        public UnitRepository()
        {
            this.models = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => this.models as IReadOnlyCollection<IMilitaryUnit>;

        public void AddItem(IMilitaryUnit model) => this.models.Add(model);

        public IMilitaryUnit FindByName(string unitTypeName) => this.models.FirstOrDefault(m => m.GetType().Name == unitTypeName);

        public bool RemoveItem(string unitTypeName) => this.models.Remove(this.models.FirstOrDefault(m => m.GetType().Name == unitTypeName));
    }
}
