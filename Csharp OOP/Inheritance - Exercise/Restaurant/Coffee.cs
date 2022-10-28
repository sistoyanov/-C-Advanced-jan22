using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double COFFEE_MILLILITERS = 50;
        private const decimal COFE_PRICE = 3.50m;

        public Coffee(string name, double caffeine) : base(name, COFE_PRICE, COFFEE_MILLILITERS)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }


    }
}
