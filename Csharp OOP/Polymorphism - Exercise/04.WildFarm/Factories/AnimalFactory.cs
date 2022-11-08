using System;
using WildFarm.Exceptions;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Animal;
using WildFarm.Models.Interfaces;


namespace WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        IAnimal animal;
        public IAnimal CreateAnimal(string[] inputDetails)
        {
            string animalType = inputDetails[0];
            string animalName = inputDetails[1];
            double animalWeight = double.Parse(inputDetails[2]);

            if (animalType == "Cat")
            {
                string livingRegion = inputDetails[3];
                string breed = inputDetails[4];

                animal = new Cat(animalName, animalWeight, livingRegion, breed);
            }
            else if (animalType == "Tiger")
            {
                string livingRegion = inputDetails[3];
                string breed = inputDetails[4];

                animal = new Tiger(animalName, animalWeight, livingRegion, breed);
            }
            else if (animalType == "Owl")
            {
                double wingSize = double.Parse(inputDetails[3]);

                animal = new Owl(animalName, animalWeight, wingSize);
            }
            else if (animalType == "Hen")
            {
                double wingSize = double.Parse(inputDetails[3]);

                animal = new Hen(animalName, animalWeight, wingSize);
            }
            else if (animalType == "Mouse")
            {
                string livingRegion = inputDetails[3];

                animal = new Mouse(animalName, animalWeight, livingRegion);
            }
            else if (animalType == "Dog")
            {
                string livingRegion = inputDetails[3];

                animal = new Dog(animalName, animalWeight, livingRegion);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidAnimalType));
            }

            return animal;
        }
    }
}
