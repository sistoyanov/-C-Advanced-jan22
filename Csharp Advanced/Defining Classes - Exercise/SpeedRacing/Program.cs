using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int count = int.Parse(Console.ReadLine());
            string input = String.Empty;

            for (int i = 0; i < count; i++)
            {
                string[] carDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = carDetails[0];
                double fuelAmount = double.Parse(carDetails[1]);
                double fuelConsumption = double.Parse(carDetails[2]);

                Car carToAdd = new Car(carModel, fuelAmount, fuelConsumption);
                cars.Add(carToAdd);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string[] carToDriveDetails = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carToDriveModel = carToDriveDetails[1];
                int carToDriveDictanse = int.Parse(carToDriveDetails[2]);

                Car carToDrive = cars.FirstOrDefault(c => c.Model == carToDriveModel);

                if (!carToDrive.Drive(carToDrive, carToDriveDictanse))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
                
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
