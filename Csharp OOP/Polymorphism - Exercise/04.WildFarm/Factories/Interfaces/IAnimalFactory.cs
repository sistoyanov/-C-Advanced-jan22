using WildFarm.Models.Interfaces;

namespace WildFarm.Factories.Interfaces
{
    public interface IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] inputDetails);
    }
}
