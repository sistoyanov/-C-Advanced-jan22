﻿using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;

namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Delicacy : IDelicacy
    {
        private string name;

        protected Delicacy(string delicacyName, double price)
        {
            this.Name = delicacyName;
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

        public double Price { get; private set; }

        public override string ToString()
        {
            return $"{this.Name} - {this.Price:f2} lv";
        }
    }
}
