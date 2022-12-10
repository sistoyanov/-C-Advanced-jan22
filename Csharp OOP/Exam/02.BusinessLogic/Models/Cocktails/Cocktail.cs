using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double currrentPrice;

        protected Cocktail(string cocktailName, string size, double price)
        {
            this.Name = cocktailName;
            this.Size = size;
            this.Price = price;
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
            get { return this.currrentPrice; }
            private set
            {
                if (this.Size == "Large")
                {
                    this.currrentPrice = value;
                }
                else if (this.Size == "Middle")
                {
                    this.currrentPrice = (value / 3) * 2;
                }
                else if (this.Size == "Small")
                {
                    this.currrentPrice = (value / 3) * 1;
                }

            }
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.Size}) - {this.Price:f2} lv";
        }
    }
}
