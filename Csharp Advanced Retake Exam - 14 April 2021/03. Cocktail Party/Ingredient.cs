using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public int Alcohol { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            StringBuilder ouput = new StringBuilder();

            ouput.AppendLine($"Ingredient: {Name}");
            ouput.AppendLine($"Quantity: {Quantity}");
            ouput.AppendLine($"Alcohol: {Alcohol}");
           
            return ouput.ToString().TrimEnd();
        }
    }
}
