using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly ICollection<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            this.models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => this.models as IReadOnlyCollection<IFormulaOneCar>;

        public void Add(IFormulaOneCar model) => this.models.Add(model);

        public bool Remove(IFormulaOneCar model) => models.Remove(model);

        public IFormulaOneCar FindByName(string name) => this.models.FirstOrDefault(m => m.Model == name);

    }
}
