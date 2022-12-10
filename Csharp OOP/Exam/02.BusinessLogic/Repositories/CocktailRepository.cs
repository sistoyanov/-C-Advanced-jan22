using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private ICollection<ICocktail> cocktails;

        public CocktailRepository()
        {
            this.cocktails = new List<ICocktail>();
        }

        public IReadOnlyCollection<ICocktail> Models => this.cocktails as IReadOnlyCollection<ICocktail>;

        public void AddModel(ICocktail cocktail) => this.cocktails.Add(cocktail);
    }
}
