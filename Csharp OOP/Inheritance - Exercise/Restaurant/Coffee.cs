using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private double coffeeMilliliters;
        private decimal coffeePrice;

        public Coffee(string name, double caffeine) : base(name, 0, 0)
        {
            this.coffeeMilliliters = 50;
            this.coffeePrice = 3.50m;
            this.Caffeine = caffeine;
        }

        public override double Milliliters { get => coffeeMilliliters; }

        public override decimal Price { get => coffeePrice; }

        public double Caffeine { get; set; }


    }
}
