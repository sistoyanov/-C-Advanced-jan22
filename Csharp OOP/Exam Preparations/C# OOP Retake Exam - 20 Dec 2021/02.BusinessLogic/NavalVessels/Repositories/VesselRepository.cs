using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;


namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private readonly ICollection<IVessel> models;

        public VesselRepository()
        {
            this.models = new List<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models => this.models as IReadOnlyCollection<IVessel>;

        public void Add(IVessel model) => this.models.Add(model);

        public bool Remove(IVessel model) => this.models.Remove(model);

        public IVessel FindByName(string name) => this.models.FirstOrDefault(m => m.Name == name);

    }
}
