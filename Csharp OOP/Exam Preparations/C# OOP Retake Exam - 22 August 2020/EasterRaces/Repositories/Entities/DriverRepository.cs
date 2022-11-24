
namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Repositories.Contracts;
    using Models.Drivers.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class DriverRepository : IRepository<IDriver>
    {
        private readonly HashSet<IDriver> drivers;

        public DriverRepository()
        {
            this.drivers = new HashSet<IDriver>();
        }

        public void Add(IDriver model) => this.drivers.Add(model);

        public IReadOnlyCollection<IDriver> GetAll() => this.drivers; //ToAtrray // as Readonly


        public IDriver GetByName(string name) => this.drivers.FirstOrDefault(d => d.Name == name);


        public bool Remove(IDriver model) => this.drivers.Remove(model);

    }
}
