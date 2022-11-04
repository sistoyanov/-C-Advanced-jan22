﻿namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly ICollection<IPrivate> privates;
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, ICollection<IPrivate> privates) : base(id, firstName, lastName, salary)
        {
            this.privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates => (IReadOnlyCollection<IPrivate>)this.privates;

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.
                AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (var item in this.Privates)
            {
                output.AppendLine($"  {item.ToString()}");
            }


            return output.ToString().TrimEnd();
        }
    }
}
