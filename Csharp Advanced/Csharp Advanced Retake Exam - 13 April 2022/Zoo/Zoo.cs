using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Zoo
{
    public class Zoo
    {
        public List<Animal> Animals;

        public Zoo(string name, int capacity)
        {
            Animals = new List<Animal>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public string AddAnimal(Animal animal)
        {
            string output = string.Empty;
            
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                output = "Invalid animal species.";

            }
            else if (animal.Diet == "herbivore" || animal.Diet == "carnivore")
            {
                if (Animals.Count < Capacity)
                {
                    Animals.Add(animal);
                    output = $"Successfully added {animal.Species} to the zoo.";
                }
                else
                {
                    output = "The zoo is full.";
                }
            }
            else
            {
                output = "Invalid animal diet.";
            }

            return output;
        }

        public int RemoveAnimals(string species)
        {
            int count = Animals.Where(a => a.Species == species).Count();
            Animals.RemoveAll(a => a.Species == species);
            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet) => Animals.Where(a => a.Diet == diet).ToList();

        public Animal GetAnimalByWeight(double weight) => Animals.FirstOrDefault(a => a.Weight == weight);

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = Animals.Where(a => a.Length >= minimumLength && a.Length <= maximumLength).Count();
            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }


    }
}
