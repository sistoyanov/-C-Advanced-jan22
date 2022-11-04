namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    using Enums;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly ICollection<IMission> missions;
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps, ICollection<IMission> missions) : base(id, firstName, lastName, salary, corps)
        {
            this.missions = missions;
        }

        public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>)this.missions;

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.
                AppendLine(base.ToString())
                .AppendLine($"Corps: {this.Corps}")
                .AppendLine("Missions:");

            foreach (var item in this.Missions)
            {
                output.AppendLine($"  {item.ToString()}");
            }


            return output.ToString().TrimEnd();
        }
    }
}
