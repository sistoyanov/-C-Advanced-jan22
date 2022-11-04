using System.Collections.Generic;

namespace MilitaryElite.Models.Interfaces
{
    internal interface ICommando : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IMission> Missions { get; }
    }
}
