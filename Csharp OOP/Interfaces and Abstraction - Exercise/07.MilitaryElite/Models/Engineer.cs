namespace MilitaryElite.Models
{
    using Interfaces;
    using MilitaryElite.Models.Enums;
    using System.Collections.Generic;
    using System.Text;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly ICollection<IRepair> repairs;
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps, ICollection<IRepair> repairs) : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>)this.repairs;

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.
                AppendLine(base.ToString())
                .AppendLine($"Corps: {this.Corps}")
                .AppendLine("Repairs:");

            foreach (var item in this.Repairs)
            {
                output.AppendLine($"  {item.ToString()}");
            }


            return output.ToString().TrimEnd();
        }
    }
}
