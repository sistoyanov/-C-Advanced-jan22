using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {

        private const double BaseCaloriesPerGram = 2;
        private const double MinGrams = 1;
        private const double MaxGrams = 200;

        private readonly Dictionary<string, double> DefaultFlourTypes = new Dictionary<string, double>
        {
            {"white", 1.5},
            {"wholegrain", 1.0},
        };

        private readonly Dictionary<string, double> DefaultBakingTechnique = new Dictionary<string, double>
        {
            {"crispy", 0.9},
            {"chewy", 1.1},
            {"homemade", 1.0},
        };

        private string flourType;
        private string bakingTechnique;
        private double grams;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (!this.DefaultFlourTypes.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            private set
            {
                if (!this.DefaultBakingTechnique.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public double Grams
        {
            get { return this.grams; }
            private set
            {
                if (value < MinGrams || value > MaxGrams)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinGrams}..{MaxGrams}].");
                }

                this.grams = value;
            }
        }

        public double CaloriesPerGram => BaseCaloriesPerGram * this.DefaultFlourTypes[this.FlourType] * this.DefaultBakingTechnique[this.BakingTechnique];

        public double TotalCalories => this.CaloriesPerGram * this.Grams;

    }
}
