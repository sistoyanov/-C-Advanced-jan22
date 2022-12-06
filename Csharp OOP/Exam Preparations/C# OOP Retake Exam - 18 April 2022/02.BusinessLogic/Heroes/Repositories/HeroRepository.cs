
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly ICollection<IHero> models;

        public HeroRepository()
        {
            this.models = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => this.models as IReadOnlyCollection<IHero>;

        public void Add(IHero model) => this.models.Add(model);

        public bool Remove(IHero model) => this.models.Remove(model);

        public IHero FindByName(string name) => this.models.FirstOrDefault(m => m.Name == name);

    }
}
