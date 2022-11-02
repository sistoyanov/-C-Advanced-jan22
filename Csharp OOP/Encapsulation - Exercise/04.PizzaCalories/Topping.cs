using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PizzaCalories
{
    public class Topping
    {

        private const double BaseCaloriesPerGram = 2;
        private const double MinGrams = 1;
        private const double MaxGrams = 50;
        private string type;
        private double weight;

        private readonly Dictionary<string, double> DefaultTypes = new Dictionary<string, double>
        {
            {"meat", 1.2},
            {"veggies", 0.8},
            {"cheese", 1.1},
            {"sauce", 0.9},
        };

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        public string Type
        {
            get { return this.type; }
            private set
            {
                if (!this.DefaultTypes.ContainsKey(value))
                {
                    throw new ArgumentException($"Cannot place {ToTitleCase(value)} on top of your pizza.");
                }
                this.type = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < MinGrams || value > MaxGrams)
                {

                    throw new ArgumentException($"{ToTitleCase(this.Type)} weight should be in the range [{MinGrams}..{MaxGrams}].");
                }

                this.weight = value;
            }
        }

        public double CaloriesPerGram => BaseCaloriesPerGram * this.DefaultTypes[this.Type];

        public double TotalCalories => this.CaloriesPerGram * this.Weight;

        private static string ToTitleCase(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input);
        }
    }
}
