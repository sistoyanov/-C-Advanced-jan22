using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double DESSERT_GRAMS = 250;
        private const double DESSERT_CALORIES = 1000;
        private const decimal DESSERT_PRICE = 5m;
        public Cake(string name) : base(name, DESSERT_PRICE, DESSERT_GRAMS, DESSERT_CALORIES)
        {

        }

    }
}
