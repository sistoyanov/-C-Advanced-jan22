
namespace Raiding.Factories.Interfaces
{
    using Raiding.Models.Interfaces;
    public interface IFactory
    {
        public IHero CreateHero(string heroName, string heroType);
    }
}
