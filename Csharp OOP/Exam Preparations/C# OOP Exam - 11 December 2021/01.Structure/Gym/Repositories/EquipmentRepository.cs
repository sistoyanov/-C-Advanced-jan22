
using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly ICollection<IEquipment> models;

        public EquipmentRepository()
        {
            this.models = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => this.models as IReadOnlyCollection<IEquipment>;

        public void Add(IEquipment model) => this.models.Add(model);

        public bool Remove(IEquipment model) => this.models.Remove(model);

        public IEquipment FindByType(string type) => this.models.FirstOrDefault(m => m.GetType().Name == type);

    }
}
