using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> cars;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.cars = new  List<Car>();
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count => cars.Count;

        public void Add(Car car)
        {
            if (!cars.Any(c =>c.LicensePlate == car.LicensePlate) && Count < Capacity && car.HorsePower <= MaxHorsePower)
            {
                cars.Add(car);
            }
        }

        public bool Remove(string licensePlate) => cars.Remove(cars.Find(c => c.LicensePlate == licensePlate));

        public Car FindParticipant(string licensePlate) => cars.FirstOrDefault(c => c.LicensePlate == licensePlate);

        public Car GetMostPowerfulCar() => cars.OrderByDescending(c => c.HorsePower).FirstOrDefault();

        public string Report()
        {
            
            return $"Race: {Name} - Type: {Type} (Laps: {Laps}){Environment.NewLine}" +
                   $"{String.Join(Environment.NewLine, cars)}";
        }


    }
}
