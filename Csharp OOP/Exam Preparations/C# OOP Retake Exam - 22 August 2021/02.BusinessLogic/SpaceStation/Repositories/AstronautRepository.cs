using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly ICollection<IAstronaut> models;

        public AstronautRepository()
        {
            this.models = new HashSet<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => this.models as IReadOnlyCollection<IAstronaut>;

        public void Add(IAstronaut model) => this.models.Add(model);

        public bool Remove(IAstronaut model) => this.models.Remove(model);

        public IAstronaut FindByName(string name) => this.models.FirstOrDefault(m => m.Name == name);

    }
}
