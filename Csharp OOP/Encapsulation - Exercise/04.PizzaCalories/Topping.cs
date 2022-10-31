using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PizzaCalories
{
    public class Topping
    {
		private string type;
        private double weight;

        private const double TOPPING_CALORIES_PER_GRAM = 2;
		private const double MEAT_CALORIES = 1.2;
		private const double VEGGIES_CALORIES = 0.8;
		private const double CHEESE_CALORIES = 1.1;
		private const double SAUSE_CALORIES = 0.9;

		public Topping(string type, double weight)
		{
			this.Type = type;
			this.Weight = weight;
		}
        public string Type
		{
			get { return type; }
			set 
            { 
                if (value == "Meat" || value == "Veggies" || value == "Cheese" || value == "Sauce")
                {
                    type = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
		}


		public double Weight
		{
			get { return weight; }
			set 
            {
                if (value > 1 && value <= 50)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException($"{this.type} weight should be in the range[1..50].");
                }
                
            }
		}

        public double ToppingCaloriesPerGram => ToppingDoughCalculateCaloriesPerGram();

        private double ToppingDoughCalculateCaloriesPerGram()
        {
            double currentMeatMod = 0;

            if (type == "Meat")
            {
                currentMeatMod = MEAT_CALORIES;
            }
            else if (type == "Veggies")
            {
                currentMeatMod = VEGGIES_CALORIES;
            }
            else if (type == "Cheese")
            {
                currentMeatMod = CHEESE_CALORIES;
            }
            else if (type == "Sauce")
            {
                currentMeatMod = SAUSE_CALORIES;
            }

            return (TOPPING_CALORIES_PER_GRAM * weight) * currentMeatMod;
        }
    }
}
