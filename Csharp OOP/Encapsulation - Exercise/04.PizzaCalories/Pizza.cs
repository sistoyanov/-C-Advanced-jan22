using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Transactions;

namespace PizzaCalories
{
    public class Pizza
    {
		private string name;
        private List<Topping> toppings;

        public Pizza(string name)
		{
			this.Name = name;
			this.toppings = new List<Topping>();
		}

		public string Name
		{
			get => this.name; 
			private set 
			{
				if (string.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
				{
					throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
				}
				
				this.name = value; 
			}
		}

		public Dough Dough { get; set; }

		public void AddTopping(Topping topping)
		{
            if (this.toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }
		public double TotalCalories => CalculatePizzaCalories();

		private double CalculatePizzaCalories()
		{
			double totalCalories = 0;

			foreach (Topping topping in this.toppings)
			{
				totalCalories += topping.TotalCalories;
			}

			totalCalories += this.Dough.TotalCalories;

			return totalCalories;
		}

		public override string ToString()
		{
			return $"{ToTitleCase(this.Name)} - {TotalCalories:f2} Calories.";
		}

        private static string ToTitleCase(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input);
        }
    }
}
