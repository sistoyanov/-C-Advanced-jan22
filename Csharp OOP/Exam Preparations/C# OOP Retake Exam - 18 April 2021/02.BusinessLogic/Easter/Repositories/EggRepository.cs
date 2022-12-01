
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly ICollection<IEgg> models;

        public EggRepository()
        {
            this.models = new HashSet<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => this.models as IReadOnlyCollection<IEgg>;

        public void Add(IEgg model)
        {
            this.models.Add(model);
        }

        public IEgg FindByName(string name) => this.models.FirstOrDefault(b => b.Name == name);

        public bool Remove(IEgg model) => this.models.Remove(model);

    }
}
