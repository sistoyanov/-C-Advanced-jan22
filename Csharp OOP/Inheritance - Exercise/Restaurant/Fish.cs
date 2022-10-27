using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Fish : MainDish
    {
        private double grams;
        public Fish(string name, decimal price) : base(name, price, 0)
        {
            this.grams = 22;
        }

        public override double Grams { get => grams; }
    }
}
