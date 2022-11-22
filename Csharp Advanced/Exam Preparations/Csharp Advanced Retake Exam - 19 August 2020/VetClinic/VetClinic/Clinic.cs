using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> pets;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.pets = new List<Pet>();
        }

        public int Capacity { get; set; }
        public int Count { get { return this.pets.Count; } }

        public void Add(Pet pet)
        {
            if (this.Count < this.Capacity)
            {
                pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet petToRemove = this.pets.FirstOrDefault(p => p.Name == name);

            if (petToRemove != null)
            {
               pets.Remove(petToRemove);
               return true;
            }
            else
            {
                return false;
            }

        }

        public Pet GetPet(string name, string owner)
        {
            return pets.FirstOrDefault(p => p.Name == name && p.Owner == owner);
        }

        public Pet GetOldestPet()
        {
            return pets.OrderByDescending(p => p.Age).FirstOrDefault();
        }

        public string GetStatistics()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("The clinic has the following patients:");

            foreach (var pet in pets)
            {
                output.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
