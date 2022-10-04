using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < count; i++)
            {
                string[] carDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = carDetails[0];
                int engineSpeed = int.Parse(carDetails[1]);
                int enginePower = int.Parse(carDetails[2]);
                int cargoWeight = int.Parse(carDetails[3]);
                string cargoType = carDetails[4];
                double tire1Pressure = double.Parse(carDetails[5]);
                int tire1Age = int.Parse(carDetails[6]);
                double tire2Pressure = double.Parse(carDetails[7]);
                int tire2Age = int.Parse(carDetails[8]);
                double tire3Pressure = double.Parse(carDetails[9]);
                int tire3Age = int.Parse(carDetails[10]);
                double tire4Pressure = double.Parse(carDetails[11]);
                int tire4Age = int.Parse(carDetails[12]);

                Engine engineToAdd = new Engine(engineSpeed, enginePower);
                Cargo cargoToAdd = new Cargo(cargoWeight, cargoType);
                Tire[] tiresToAdd = new Tire[4]
                {
                    new Tire(tire1Pressure, tire1Age),
                    new Tire(tire2Pressure, tire2Age),
                    new Tire(tire3Pressure, tire3Age),
                    new Tire(tire4Pressure, tire4Age)
                };

                Car carToAdd = new Car(carModel, engineToAdd, cargoToAdd, tiresToAdd);
                cars.Add(carToAdd);
            }

            string command = Console.ReadLine();
            List<string> carsToPrint = new List<string>();

            if (command == "fragile")
            {
                carsToPrint = cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(c => c.Pressure < 1)).Select(c => c.Model).ToList();
            }
            else if (command == "flammable")
            {
                carsToPrint = cars.Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250).Select(c => c.Model).ToList();
            }

            foreach (var car in carsToPrint)
            {
                Console.WriteLine(car);
            }
        }
    }
}
