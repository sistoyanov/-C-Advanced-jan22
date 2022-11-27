﻿
namespace Bakery.Models.BakedFoods
{
    using BakedFoods.Contracts;
    using Utilities.Messages;
    using System;
    public abstract class BakedFood : IBakedFood
    {
        private string name;
        private int portion;
        private decimal price;

        protected BakedFood(string name, int portion, decimal price)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
        }

        public string Name
        {
            get { return this.name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName));
                }

                this.name = value; 
            }
        }

        public int Portion
        {
            get { return this.portion; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPortion));
                }

                this.portion = value; 
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPrice));
                }

                this.price = value; 
            }
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.Portion}g - {this.Price:f2}";
        }
    }
}
