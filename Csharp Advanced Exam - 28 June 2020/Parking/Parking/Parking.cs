using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Parking
{
    internal class Parking
    {
        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.cars = new List<Car>();
        }
        private List<Car> cars;
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.cars.Count; }  }

        public void Add(Car car)
        {
            if (this.Count < this.Capacity)
            {
                this.cars.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = this.cars.FirstOrDefault(cars => cars.Manufacturer == manufacturer && cars.Model == model);

            if (carToRemove != null)
            {
                cars.Remove(carToRemove);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Car GetLatestCar()
        {
            Car carToPrint = this.cars.OrderByDescending(c => c.Year).FirstOrDefault();
            return carToPrint;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car carToPrint = this.cars.FirstOrDefault(cars => cars.Manufacturer == manufacturer && cars.Model == model);
            return carToPrint;
        }

        public string GetStatistics()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"The cars are parked in {this.Type}:");

            foreach (var car in this.cars)
            {
                output.AppendLine(car.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
