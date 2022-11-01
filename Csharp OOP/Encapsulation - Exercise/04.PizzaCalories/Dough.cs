using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
		private string flourType;
        private string bakingTechnique;
        private double doughWeight;

		private const double DOUGH_CALORIES_PER_GRAM = 2;

		private const double WHITE_FLOUR = 1.5;
		private const double WHOLEGRAIN_FLOUR = 1.0;

		private const double CRISPY_DOUGH = 0.9;
		private const double CHEWY_DOUGH = 1.1;
		private const double HOME_MADE_DOUGH = 1.0;


        public Dough(string flourType, string bakingTechnique, double doughWeight)
		{
			this.FlourType = flourType;
			this.BakingTechnique = bakingTechnique;
			this.DoughWeight = doughWeight;
        }

        public string FlourType
        {
			get => this.flourType;
			private set 
			{
				if (value == "white" || value == "wholegrain")
				{
                    this.flourType = value;
                }
				else
				{
                    throw new ArgumentException("Invalid type of dough.");
                }

			}
		}

		public string BakingTechnique
        {
			get => this.bakingTechnique;
			private set 
			{
                if (value == "crispy" || value == "chewy" || value == "homemade")
                {
                    this.bakingTechnique = value;
                }
				else
				{
                    throw new ArgumentException("Invalid type of dough.");
                }

			}
		}

		public double DoughWeight
        {
			get =>this.doughWeight; 
			private set 
			{
				if (value > 0 && value <= 200)
				{
                    this.doughWeight = value;
                }
				else
				{
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

            }
				
		}

		public double DoughCaloriesPerGram => DoughCalculateCaloriesPerGram();

		private double DoughCalculateCaloriesPerGram()
		{
			double currentFlourTypeMod = 0;
			double currentDoughTypeMod = 0;

			if (this.flourType == "white")
			{
				currentFlourTypeMod = WHITE_FLOUR;
			}
			else if (this.flourType == "wholegrain")
			{
				currentFlourTypeMod = WHOLEGRAIN_FLOUR;
			}

			if (this.bakingTechnique == "crispy")
			{
				currentDoughTypeMod = CRISPY_DOUGH;
			}
			else if (this.bakingTechnique == "chewy")
			{
				currentDoughTypeMod = CHEWY_DOUGH;
			}
			else if (this.bakingTechnique == "homemade")
			{
				currentDoughTypeMod = HOME_MADE_DOUGH;
			}

			return (DOUGH_CALORIES_PER_GRAM * this.doughWeight) * currentFlourTypeMod * currentDoughTypeMod;
		}

    }
}
