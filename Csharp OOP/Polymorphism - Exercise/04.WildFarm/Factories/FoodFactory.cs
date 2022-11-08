
namespace WildFarm.Factories
{
    using System;
    using Interfaces;
    using WildFarm.Exceptions;
    using WildFarm.Models.Food;
    using WildFarm.Models.Interfaces;
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string foodType, int foodQuantity)
        {
            IFood food;

            if (foodType == "Fruit")
            {
                food = new Fruit(foodQuantity);
            }
            else if (foodType == "Meat")
            {
                food = new Meat(foodQuantity);
            }
            else if (foodType == "Seeds")
            {
                food = new Seeds(foodQuantity);
            }
            else if (foodType == "Vegetable")
            {
                food = new Vegetable(foodQuantity);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidFoodType));
            }

            return food;
        }
    }
}
