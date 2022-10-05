using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }
        private List<Car> cars;
        private int capacity;
        public int Count { get {return this.cars.Count; } }
        public string AddCar(Car car)
        {
            if(cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }
            else if (this.Count >= this.capacity)
            {
                return $"Parking is full!";
            }
            else
            {
                cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
            
                       
        }
        public string RemoveCar(string registrationNumber)
        {
            if (cars.Any(c => c.RegistrationNumber == registrationNumber))
            {
                Car carToRemove = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
                cars.Remove(carToRemove);
                return $"Successfully removed {registrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }
        public Car GetCar(string registrationNumber)
        {
            Car carToDisplay = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
            return carToDisplay;
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registration in registrationNumbers)
            {
                this.RemoveCar(registration);
            };
        }
    }
}
