
namespace MilitaryElite.Models.Interfaces
{
    using System.Collections.Generic;
    public interface IEngineer : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IRepair> Repairs { get; }
    }
}
