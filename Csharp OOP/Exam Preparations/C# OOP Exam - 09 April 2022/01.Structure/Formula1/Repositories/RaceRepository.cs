using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly ICollection<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => this.models as IReadOnlyCollection<IRace>;

        public void Add(IRace model) => this.models.Add(model);

        public bool Remove(IRace model) => models.Remove(model);

        public IRace FindByName(string name) => this.models.FirstOrDefault(m => m.RaceName == name);
    }
}
