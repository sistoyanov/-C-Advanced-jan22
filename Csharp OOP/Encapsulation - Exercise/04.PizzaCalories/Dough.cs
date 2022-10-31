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
			get { return flourType; }
			private set 
			{
				if (value == "White" || value == "Wholegrain")
				{
                    flourType = value;
                }
				else
				{
					throw new ArgumentException("Invalid type of dough.");
				}
				
			}
		}

		public string BakingTechnique
        {
			get { return bakingTechnique; }
			private set 
			{
                if (value == "Crispy" || value == "Chewy" || value == "Homemade")
                {
                    bakingTechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
				
			}
		}

		public double DoughWeight
        {
			get { return doughWeight; }
			private set 
			{
				if (value > 0 && value <= 200)
				{
                    doughWeight = value;
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

			if (flourType == "White")
			{
				currentFlourTypeMod = WHITE_FLOUR;
			}
			else if (flourType == "Wholegrain")
			{
				currentFlourTypeMod = WHOLEGRAIN_FLOUR;
			}

			if (bakingTechnique == "Crispy")
			{
				currentDoughTypeMod = CRISPY_DOUGH;
			}
			else if (bakingTechnique == "Chewy")
			{
				currentDoughTypeMod = CHEWY_DOUGH;
			}
			else if (bakingTechnique == "Homemade")
			{
				currentDoughTypeMod = HOME_MADE_DOUGH;
			}

			return (DOUGH_CALORIES_PER_GRAM * doughWeight) * currentFlourTypeMod * currentDoughTypeMod;
		}

    }
}
