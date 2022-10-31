using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
		private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
		{
			this.Name = name;
			this.Money = money;
			this.products = new List<Product>();
		}

        public string Name
		{
			get { return this.name; }
			set 
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Name cannot be empty");
				}

				this.name = value; 
			}
		}

		public decimal Money
		{
			get { return this.money; }
			set 
			{
				if (value < 0)
				{
					throw new ArgumentException("Money cannot be negative");
				}

				this.money = value; 
			}
		}

        

        public void BuyProduct(Product product)
        {
            if (product.Cost <= money)
            {
                this.money -= product.Cost;
                this.products.Add(product);
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            List<string> productsPurchased = new List<string>();

            foreach (var product in this.products)
            {
                productsPurchased.Add(product.Name);
            }

            if (productsPurchased.Count != 0)
            {
                return $"{Name} - {string.Join(", ", productsPurchased)}";
            }
			else
			{
                return $"{Name} - Nothing bought";
            }
            
        }

    }
}
