using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private double grams;
        private double calories;
        private decimal price;
        public Cake(string name) : base(name, 0, 0, 0)
        {
            this.grams = 250;
            this.calories = 1000;
            this.price = 5m;
        }

        public override double Grams { get => grams; }
        public override double Calories { get => calories; }
        public override decimal Price { get => price; }

    }
}
