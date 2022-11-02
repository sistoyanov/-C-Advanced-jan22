using BirthdayCelebrations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{ 
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
          
            List<IBirthdate> birthDateList = new List<IBirthdate>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputDetails = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = inputDetails[0];

                if (type == "Citizen")
                {
                    string name = inputDetails[1];
                    int age = int.Parse(inputDetails[2]);
                    string personId = inputDetails[3];
                    string personBirthDate = inputDetails[4];

                    Citizen citizen = new Citizen(name, age, personId, personBirthDate);
                    birthDateList.Add(citizen);
                }
                else if (type == "Pet")
                {
                    string petName = inputDetails[1];
                    string petBirthDate = inputDetails[2];

                    Pet pet = new Pet(petName, petBirthDate);
                    birthDateList.Add((pet));
                }
                else if (type == "Robot")
                {
                    string model = inputDetails[1];
                    string robotId = inputDetails[2];

                    Robot robot = new Robot(model, robotId);
                }

            }

            string searchedNum = Console.ReadLine();
            List<string> printList = birthDateList.Where(x => x.BurthDate.EndsWith(searchedNum)).Select(x => x.BurthDate).ToList();
            Console.WriteLine(String.Join(Environment.NewLine, printList));
        }
    }
}
