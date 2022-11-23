
namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Repositories.Contracts;
    using Models.Drivers.Contracts;
    using System.Collections.Generic;

    public class DriverRepository : IRepository<IDriver>
    {
        public void Add(IDriver model)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IDriver GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IDriver model)
        {
            throw new System.NotImplementedException();
        }
    }
}
