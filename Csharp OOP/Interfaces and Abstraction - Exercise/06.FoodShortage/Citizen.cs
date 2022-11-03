using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IBuyer
    {
        public Citizen(string name, int age, string id, string burthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BurthDate = burthDate;
            this.Food = 0;
        }
        
        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }

        public string BurthDate { get ; set ; }

        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
