using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.ingredients = new List<Ingredient>();
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel { get { return ingredients.Sum(i => i.Alcohol) ; } }

        public void Add(Ingredient ingredient)
        {
            
            if (!ingredients.Any(i => i.Name == ingredient.Name) && MaxAlcoholLevel > (CurrentAlcoholLevel + ingredient.Alcohol) && Capacity > ingredients.Count())
            {
                ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {

            return ingredients.Remove(ingredients.FirstOrDefault(i => i.Name == name));
        }

        public Ingredient FindIngredient(string name)
        {
            return ingredients.FirstOrDefault(i => i.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return ingredients.OrderByDescending(i => i.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingredient in ingredients)
            {
                output.AppendLine(ingredient.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
