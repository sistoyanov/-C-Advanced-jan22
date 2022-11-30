using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        IRepository<IDecoration> decorations;
        ICollection<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAquariumType));
            }

            aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAquariumType));
            }

            decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decorationToAdd = decorations.FindByType(decorationType);
            IAquarium aquariumToReciveDecoratrion = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (decorationToAdd is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquariumToReciveDecoratrion.AddDecoration(decorationToAdd);
            this.decorations.Remove(decorationToAdd);
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
            IAquarium aquariumForFish = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidFishType));
            }


            if (fishType == "FreshwaterFish" && aquariumForFish.GetType().Name == "FreshwaterAquarium")
            {
                aquariumForFish.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumForFish.Name);
            }
            else if (fishType == "SaltwaterFish" && aquariumForFish.GetType().Name == "SaltwaterAquarium")
            {
                aquariumForFish.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumForFish.Name);
            }
            else
            {
                return string.Format(OutputMessages.UnsuitableWater);
            }
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquariumToFeed = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            aquariumToFeed.Feed();
            int fishCount = aquariumToFeed.Fish.Count;

            return string.Format(OutputMessages.FishFed, fishCount);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquariumToCalculate = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            decimal sum = aquariumToCalculate.Fish.Sum(f => f.Price) + aquariumToCalculate.Decorations.Sum(d => d.Price);

            //return $"The value of Aquarium {aquariumName} is {sum:f2}.";
            return string.Format(OutputMessages.AquariumValue, aquariumName, sum);
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();

            foreach (IAquarium aquarium in aquariums)
            {
                output.AppendLine(aquarium.GetInfo());
            }

            return output.ToString().TrimEnd();
        }
    }
}
