using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
		private string name;
		private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
		{
			this.Name = name;
			this.Toppings = new List<Topping>();
		
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		
		public List<Topping> Toppings
		{
			get { return toppings; }
			set { toppings = value; }
		}


		public Dough Dough { get; set; }

	}
}
