using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        private readonly ICollection<T> repository;

        public void Add(T model) => this.repository.Add(model);

        public IReadOnlyCollection<T> GetAll() => this.repository as IReadOnlyCollection<T>;

        public T GetByName(string name) => this.repository.FirstOrDefault(t => t.GetType().Name == name); // check if where should be used

        public bool Remove(T model) => this.repository.Remove(model);

    }
}
