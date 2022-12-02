using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly ICollection<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new HashSet<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.models as IReadOnlyCollection<IPlanet>;

        public void Add(IPlanet model) => this.models.Add(model);

        public bool Remove(IPlanet model) => this.models.Remove(model);

        public IPlanet FindByName(string name) => this.models.FirstOrDefault(m => m.Name == name);
    }
}
