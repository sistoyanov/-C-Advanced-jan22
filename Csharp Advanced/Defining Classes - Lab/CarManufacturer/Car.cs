using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Schema;

namespace CarManufacturer
{
    public class Car
    {

        public Car(string make, string model, int year, int horsePower, double fuelQuantity,
            double fuelConsumption, int engineIndex, int tiresIndex, double totalPressure)
        {
            Make = make;
            Model = model;
            Year = year;
            HorsePower = horsePower;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            EngineIndex = engineIndex;
            TiresIndex = tiresIndex;
            TotalPressure = totalPressure;
        }


        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int HorsePower { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public int EngineIndex { get; set; }

        public int TiresIndex { get; set; }

        public double TotalPressure { get; set; }


        public double Drive(double fuelQuantity, double fuelConsumption, int distance)
        {
            fuelQuantity -= (FuelConsumption / 100) * distance;

            return fuelQuantity;
        }

    }
}
