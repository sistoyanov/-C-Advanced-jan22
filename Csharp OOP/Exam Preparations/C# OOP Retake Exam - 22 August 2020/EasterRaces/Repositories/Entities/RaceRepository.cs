
namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Repositories.Contracts;
    using Models.Races.Contracts;
    using System.Collections.Generic;

    public class RaceRepository : IRepository<IRace>
    {
        public void Add(IRace model)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IRace GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IRace model)
        {
            throw new System.NotImplementedException();
        }
    }
}
