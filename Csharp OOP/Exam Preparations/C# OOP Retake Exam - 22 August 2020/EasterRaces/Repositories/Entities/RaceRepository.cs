
namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Repositories.Contracts;
    using Models.Races.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly HashSet<IRace> races;

        public RaceRepository()
        {
            this.races = new HashSet<IRace>();
        }

        public void Add(IRace model) => this.races.Add(model);


        public IReadOnlyCollection<IRace> GetAll() => this.races;


        public IRace GetByName(string name) => this.races.FirstOrDefault(r => r.Name == name);

        public bool Remove(IRace model) => this.races.Remove(model);

    }
}
