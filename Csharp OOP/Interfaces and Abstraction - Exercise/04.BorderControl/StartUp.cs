using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
          
            List<IControlable> entranceList = new List<IControlable>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputDetails = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (inputDetails.Count() == 3)
                {
                    string name = inputDetails[0];
                    int age = int.Parse(inputDetails[1]);
                    string personId = inputDetails[2];

                    Citizen citizen = new Citizen(name, age);
                    citizen.Id = personId;
                    entranceList.Add(citizen);
                }
                else if (inputDetails.Count() == 2)
                {
                    string model = inputDetails[0];
                    string robotId = inputDetails[1];

                    Robot robot = new Robot(model);
                    robot.Id = robotId;
                    entranceList.Add(robot);
                }
            }

            string searchedNum = Console.ReadLine();
            List<string> detainedList = entranceList.Where(x => x.Id.EndsWith(searchedNum)).Select(x => x.Id).ToList();
            Console.WriteLine(String.Join(Environment.NewLine, detainedList));
        }
    }
}
