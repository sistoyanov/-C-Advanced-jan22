using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private readonly ICollection<IRacer> models;

        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => this.models as IReadOnlyCollection<IRacer>;

        public void Add(IRacer racer)
        {
            if (racer is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            this.models.Add(racer);
        }
        public bool Remove(IRacer racer) => this.models.Remove(racer);

        public IRacer FindBy(string property) => this.models.FirstOrDefault(m => m.Username == property);
    }
}
