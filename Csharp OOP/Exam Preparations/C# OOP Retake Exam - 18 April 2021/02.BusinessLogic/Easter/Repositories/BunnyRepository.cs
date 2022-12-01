﻿using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly ICollection<IBunny> models;
        public BunnyRepository()
        {
            this.models = new HashSet<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => this.models as IReadOnlyCollection<IBunny>;

        public void Add(IBunny model)
        {
            this.models.Add(model);
        }

        public IBunny FindByName(string name) => this.models.FirstOrDefault(b => b.Name == name);

        public bool Remove(IBunny model) => this.models.Remove(model);

    }
}
