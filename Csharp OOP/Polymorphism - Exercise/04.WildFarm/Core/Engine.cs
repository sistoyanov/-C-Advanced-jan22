using System;
using System.Collections.Generic;
using WildFarm.Core.Interfaces;
using WildFarm.Factories.Interfaces;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;

        IAnimal animal;
        IFood food;
        ICollection<IAnimal> animals;

        public Engine(IReader reader ,IWriter writer, IFoodFactory foodFactory, IAnimalFactory animalFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;
            this.animals = new HashSet<IAnimal>();
        }

        public void Run()
        {
            string input = string.Empty;

            while ((input = reader.ReadLine()) != "End")
            {
                try
                {
                    string[] animalDetails = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    animal = animalFactory.CreateAnimal(animalDetails);

                    string[] foodDetails = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string foodType = foodDetails[0];
                    int foodQuantity = int.Parse(foodDetails[1]);
                    food = foodFactory.CreateFood(foodType, foodQuantity);

                    this.writer.WriteLine(animal.ProduceSound());
                    animal.Eat(food);
                }
                catch (ArgumentException ae)
                {

                    this.writer.WriteLine(ae.Message);
                }

                animals.Add(animal);

            }

            PrintAnimals();
        }

        private void PrintAnimals()
        {
            foreach (IAnimal animal in animals)
            {
                this.writer.WriteLine(animal.ToString());
            }
        }
    }
}
