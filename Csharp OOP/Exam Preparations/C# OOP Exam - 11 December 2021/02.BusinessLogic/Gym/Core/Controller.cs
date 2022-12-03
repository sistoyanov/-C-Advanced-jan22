
using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private IRepository<IEquipment> equipment;
        private ICollection<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gymToAdd;
            
            if (gymType == "BoxingGym")
            {
                gymToAdd = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gymToAdd = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            this.gyms.Add(gymToAdd);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipmentToAdd;

            if (equipmentType == "BoxingGloves")
            {
                equipmentToAdd = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipmentToAdd = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            this.equipment.Add(equipmentToAdd);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipmentToInsert = this.equipment.FindByType(equipmentType);
            IGym gymToRecive = this.gyms.FirstOrDefault(g => g.Name == gymName);

            if (equipmentToInsert is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            gymToRecive.AddEquipment(equipmentToInsert);
            this.equipment.Remove(equipmentToInsert);
            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athleteToAdd;
            IGym gymToExercise = this.gyms.FirstOrDefault(g => g.Name == gymName);

            if (athleteType == "Boxer")
            {
                athleteToAdd = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == "Weightlifter")
            {
                athleteToAdd = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }


            if (athleteType == "Boxer" && gymToExercise.GetType().Name == "BoxingGym")
            {
                gymToExercise.AddAthlete(athleteToAdd);
                return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }
            else if (athleteType == "Weightlifter" && gymToExercise.GetType().Name == "WeightliftingGym")
            {
                gymToExercise.AddAthlete(athleteToAdd);
                return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }
            else
            {
                return string.Format(OutputMessages.InappropriateGym);
            }

        }

        public string TrainAthletes(string gymName)
        {
            IGym gymToTrain = this.gyms.FirstOrDefault(g => g.Name == gymName);
            
            foreach (IAthlete athlete in gymToTrain.Athletes)
            {
                athlete.Exercise();
            }

            return string.Format(OutputMessages.AthleteExercise, gymToTrain.Athletes.Count);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gymToWeight = this.gyms.FirstOrDefault(g => g.Name == gymName);
            double weigth = gymToWeight.EquipmentWeight;
            return $"The total weight of the equipment in the gym {gymName} is {weigth:f2} grams.";
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();

            foreach (IGym gym in this.gyms)
            {
                output.AppendLine(gym.GymInfo());
            }

            return output.ToString().TrimEnd();
        }

    }
}
