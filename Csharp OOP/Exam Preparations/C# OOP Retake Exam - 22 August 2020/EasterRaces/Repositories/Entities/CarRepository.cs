
namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Repositories.Contracts;
    using Models.Cars.Contracts;
    using System.Collections.Generic;

    public class CarRepository : IRepository<ICar>
    {
        public void Add(ICar model)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public ICar GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(ICar model)
        {
            throw new System.NotImplementedException();
        }
    }
}
