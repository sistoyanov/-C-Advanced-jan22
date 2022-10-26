using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace SpeedRacing
{
    internal class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumption;
            this.TravelledDistance = 0;
        }
        
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public bool Drive(Car carToDrive, int amaountKM)
        {
            double neededFuel = carToDrive.FuelConsumptionPerKilometer * amaountKM;

            if (carToDrive.FuelAmount >= neededFuel)
            {
                carToDrive.FuelAmount -= neededFuel;
                carToDrive.TravelledDistance += amaountKM;
                return true;
            }
            else
            {
                return false;
            }

        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}";
        }
    }
}
