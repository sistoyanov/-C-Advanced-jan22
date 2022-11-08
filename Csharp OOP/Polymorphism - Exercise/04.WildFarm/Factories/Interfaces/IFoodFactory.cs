using WildFarm.Models.Interfaces;

namespace WildFarm.Factories.Interfaces
{
    public interface IFoodFactory
    {
        public IFood CreateFood(string foodType, int foodQuantity);
    }
}
