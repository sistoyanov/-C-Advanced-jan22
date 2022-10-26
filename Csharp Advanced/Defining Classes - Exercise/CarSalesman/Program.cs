using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int enginesCount = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < enginesCount; i++)
            {
                string[] engineDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string engineModel = engineDetails[0];
                int enginePower = int.Parse(engineDetails[1]);

                Engine engineToAdd = new Engine(engineModel, enginePower);

                if (engineDetails.Length >= 3)
                {
                    int engineDisplacement = 0;

                    if (int.TryParse(engineDetails[2], out engineDisplacement))
                    {
                        engineToAdd.Displacement = engineDisplacement;
                    }
                    else
                    {
                        string engineEfficienc = engineDetails[2];
                        engineToAdd.Efficiency = engineEfficienc;
                    }
                }

                if (engineDetails.Length == 4)
                {
                    string engineEfficiency = engineDetails[3];
                    engineToAdd.Efficiency = engineEfficiency;
                }

                engines.Add(engineToAdd);
            }

            int carsCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] carDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = carDetails[0];
                string carEngine = carDetails[1];

                Engine carEngineToAdd = engines.FirstOrDefault(e => e.Model == carEngine);
                Car carToAdd = new Car(carModel, carEngineToAdd);

                if (carDetails.Length >= 3)
                {
                    int carWeight = 0;

                    if (int.TryParse(carDetails[2], out carWeight))
                    {
                        carToAdd.Weight = carWeight;
                    }
                    else
                    {
                        string carColor = carDetails[2];
                        carToAdd.Color = carColor;
                    }
              
                }

                if (carDetails.Length == 4)
                {
                    string carColor = carDetails[3];
                    carToAdd.Color = carColor;
                }

                cars.Add(carToAdd);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
