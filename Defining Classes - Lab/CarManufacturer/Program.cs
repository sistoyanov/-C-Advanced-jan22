using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<List<double>> listTiresYears = new List<List<double>>();
            List<List<double>> listTiresPressures = new List<List<double>>();
            List<int> listHorsePowers = new List<int>();
            List<double> listCubicCapacity = new List<double>();

            List<Car> listCars = new List<Car>();

            string input = String.Empty;

            Tire tires = new Tire();
            Engine engine = new Engine();

            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] splitted = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);

                List<double> listYears = tires.GetYearInfo(splitted);
                List<double> listPressures = tires.GetPressureInfo(splitted);

                listTiresYears.Add(listYears);
                listTiresPressures.Add(listPressures);
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] splitted = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                listHorsePowers.Add(engine.GetHorsePower(splitted));
                listCubicCapacity.Add(engine.GetCubicCapacity(splitted));
            }

            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] splitted = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = splitted[0];
                string model = splitted[1];
                int year = int.Parse(splitted[2]);
                double fuelQuantity = double.Parse(splitted[3]);
                double fuelConsumption = double.Parse(splitted[4]);
                int engineIndex = int.Parse(splitted[5]);
                int tiresIndex = int.Parse(splitted[6]);

                int horsePower = listHorsePowers[engineIndex];
                double pressure = tires.GetSumPressure(listTiresPressures, tiresIndex);

                Car car = new Car(make, model, year, horsePower, fuelQuantity, fuelConsumption,
                    engineIndex, tiresIndex, pressure);

                listCars.Add(car);
            }

            foreach (var car in listCars)
            {
                if (car.Year >= 2017 && car.HorsePower > 330 && car.TotalPressure > 9 && car.TotalPressure < 10)
                {
                    car.FuelQuantity = car.Drive(car.FuelQuantity, car.FuelConsumption, 20);

                    Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}\nHorsePowers: {car.HorsePower}\nFuelQuantity: {car.FuelQuantity}");
                };

            }
        }
    }
}
