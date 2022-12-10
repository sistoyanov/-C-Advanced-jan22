using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;

        protected Cocktail(string cocktailName, string size, double price)
        {
            this.Name = cocktailName;
            this.Price = price;
            this.Size = size;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                this.name = value;
            }
        }

        public string Size { get; private set; }

        public double Price
        {
            get { return this.price; }
            private set
            {
                if (this.Size == "Large")
                {
                    this.price = value;
                }
                else if (this.Size == "Middle")
                {
                    this.price = Math.Round(value * 0.66);
                }
                else if (this.Size == "Small")
                {
                    this.price = Math.Round(value * 0.33);
                }

            }
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.Size}) - {this.Price:f2} lv";
        }
    }
}
