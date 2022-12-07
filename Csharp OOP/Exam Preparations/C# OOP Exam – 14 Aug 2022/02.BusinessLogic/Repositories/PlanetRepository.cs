
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly ICollection<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.models as IReadOnlyCollection<IPlanet>;

        public void AddItem(IPlanet model) => this.models.Add(model);

        public IPlanet FindByName(string planetName) => this.models.FirstOrDefault(m => m.Name == planetName);

        public bool RemoveItem(string planetName) => this.models.Remove(this.models.FirstOrDefault(m => m.Name == planetName));
    }
}
