
namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Repositories.Contracts;
    using Models.Cars.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class CarRepository : IRepository<ICar>
    {
        private readonly HashSet<ICar> cars;

        public CarRepository()
        {
            this.cars = new HashSet<ICar>();
        }

        public void Add(ICar model) => this.cars.Add(model);

        public IReadOnlyCollection<ICar> GetAll() => this.cars;

        public ICar GetByName(string name) => this.cars.FirstOrDefault(c => c.Model == name);

        public bool Remove(ICar model) => this.cars.Remove(model);

    }
}
