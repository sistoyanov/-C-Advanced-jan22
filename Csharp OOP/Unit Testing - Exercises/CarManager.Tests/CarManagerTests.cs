namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void CarPrivateConstructor_ShouldSet_FuelAmountToZero()
        {
            double expectedFuelAmount = 0;
            Car newCar = new Car("BMW", "X5", 10, 100);
            double actualFuelAmaount = newCar.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmaount);
        }

        [Test]
        public void CarConstructor_ShouldSet_DataCorrectlly()
        {
            string expectedCarMake = "BMW";
            string expectedCarModel = "X5";
            double expectedFuelConsuption = 10;
            double expectedFuelCapcity = 100;

            Car newCar = new Car(expectedCarMake, expectedCarModel, expectedFuelConsuption, expectedFuelCapcity);

            string actualCarMake = newCar.Make;
            string actualCarModel = newCar.Model;
            double actualFuelConsuption = newCar.FuelConsumption;
            double actualFuelCapcity = newCar.FuelCapacity;

            Assert.AreEqual(expectedCarMake, actualCarMake);
            Assert.AreEqual(expectedCarModel, actualCarModel);
            Assert.AreEqual(expectedFuelConsuption, actualFuelConsuption);
            Assert.AreEqual(expectedFuelCapcity, actualFuelCapcity);
        }

        //[Test]
        //public void CarMakeProperty_ShouldReturnMake()
        //{
        //    string expectedCarMake = "BMW";
        //    Car newCar = new Car(expectedCarMake, "X5", 10, 100);
        //    string actualCarMake = newCar.Make;

        //    Assert.AreEqual(expectedCarMake, actualCarMake);
        //}


        [TestCase (null)]
        [TestCase ("")]
        public void CarMakeProperty_ShouldThrowException_IfMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "X5", 10, 100));
        }

        //[Test]
        //public void CarMakeProperty_ShouldSetMake()
        //{
        //    string expectedCarMake = "BMW";
        //    Car newCar = new Car(expectedCarMake, "X5", 10, 100);
        //    string actualCarMake = newCar.Make;

        //    Assert.AreEqual(expectedCarMake, actualCarMake);
        //}

        //[Test]
        //public void CarModelProperty_ShouldReturnMake()
        //{
        //    string expectedCarModel = "X5";
        //    Car newCar = new Car("BMW", expectedCarModel, 10, 100);
        //    string actualCarModel = newCar.Model;

        //    Assert.AreEqual(expectedCarModel, actualCarModel);
        //}


        [TestCase(null)]
        [TestCase("")]
        public void CarModelProperty_ShouldThrowException_IfMakeIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", model, 10, 100));
        }

        //[Test]
        //public void CarModelProperty_ShouldSetMake()
        //{
        //    string expectedCarModel = "X5";
        //    Car newCar = new Car("BMW", expectedCarModel, 10, 100);
        //    string actualCarModel = newCar.Model;

        //    Assert.AreEqual(expectedCarModel, actualCarModel);
        //}

        //[Test]
        //public void CarFuelConsumptionProperty_ShouldReturnFuelConsumption()
        //{
        //    double expectedCarFuelConsumption = 10;
        //    Car newCar = new Car("BMW", "X5", expectedCarFuelConsumption, 100);
        //    double actualCarFuelConsumption = newCar.FuelConsumption;

        //    Assert.AreEqual(expectedCarFuelConsumption, actualCarFuelConsumption);
        //}


        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-25647)]
        [TestCase(double.MinValue)]
        public void CarFuelConsumptionProperty_ShouldThrowException_IfItIsZeroOrBelow(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", "X5", fuelConsumption, 100));
        }

        //[Test]
        //public void CarFuelConsumptionProperty_ShouldSetFuelConsumption()
        //{
        //    double expectedCarFuelConsumption = 10;
        //    Car newCar = new Car("BMW", "X5", expectedCarFuelConsumption, 100);
        //    double actualCarFuelConsumption = newCar.FuelConsumption;

        //    Assert.AreEqual(expectedCarFuelConsumption, actualCarFuelConsumption);
         
        //}

        //[Test]
        //public void CarFuelAmountProperty_ShouldReturnFuelAmount()
        //{
        //    double expectedCarFuelAmount = 0;
        //    Car newCar = new Car("BMW", "X5", 10, 100);
        //    double actualCarFuelAmount = newCar.FuelAmount;

        //    Assert.AreEqual(expectedCarFuelAmount, actualCarFuelAmount);
        //}


        [TestCase(-1)]
        [TestCase(-25647)]
        [TestCase(double.MinValue)]
        public void CarFuelFuelAmounProperty_ShouldThrowException_IfItIsBelowZero(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", "X5", fuelConsumption, 100));
        }

        //[Test]
        //public void CarFuelAmountProperty_ShouldSetFuelAmount()
        //{
        //    double expectedCarFuelAmount = 0;
        //    Car newCar = new Car("BMW", "X5", 10, 100);
        //    double actualCarFuelAmount = newCar.FuelAmount;

        //    Assert.AreEqual(expectedCarFuelAmount, actualCarFuelAmount);

        //}

        //[Test]
        //public void CarFuelFuelCapacityProperty_ShouldReturnFuelCapacity()
        //{
        //    double expectedCarFuelCapacity = 100;
        //    Car newCar = new Car("BMW", "X5", 10, expectedCarFuelCapacity);
        //    double actualCarFuelCapacity = newCar.FuelCapacity;

        //    Assert.AreEqual(expectedCarFuelCapacity, actualCarFuelCapacity);
        //}


        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-25647)]
        [TestCase(double.MinValue)]
        public void CarFuelFuelCapacityProperty_ShouldThrowException_IfItIsZeroOrBelow(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", "X5", 10, fuelCapacity));
        }

        //[Test]
        //public void CarFuelFuelCapacityProperty_ShouldSetFuelCapacity()
        //{
        //    double expectedCarFuelCapacity = 100;
        //    Car newCar = new Car("BMW", "X5", 10, expectedCarFuelCapacity);
        //    double actualCarFuelCapacity = newCar.FuelCapacity;

        //    Assert.AreEqual(expectedCarFuelCapacity, actualCarFuelCapacity);

        //}

        [Test]

        public void CarRefuelMethod_ShouldIncreaseFuelAmount()
        {
            double fuelToRefuel = 10;

            Car newCar = new Car("BMW", "X5", 10, 100);
            double expectedCarFuelAmount = newCar.FuelAmount + 10;

            newCar.Refuel(fuelToRefuel);
            double actualCarFuelAmount = newCar.FuelAmount;

            Assert.AreEqual(expectedCarFuelAmount, actualCarFuelAmount);
        }

        [Test]

        public void CarRefuelMethod_ShouldIncreaseFuelAmountEqualToFuelCapacity_IfRefuelIsGreaterThanCapacity()
        {
            double fuelToRefuel = 180;

            Car newCar = new Car("BMW", "X5", 10, 100);
            double expectedCarFuelAmount = 100;

            newCar.Refuel(fuelToRefuel);
            double actualCarFuelAmount = newCar.FuelAmount;

            Assert.AreEqual(expectedCarFuelAmount, actualCarFuelAmount);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-25647)]
        [TestCase(double.MinValue)]

        public void CarRefuelMethod_ShouldThrowException_IfFuelToRefuelIsZeroOrBelow(double fuelToRefuel)
        {
            Car newCar = new Car("BMW", "X5", 10, 100);

            Assert.Throws<ArgumentException>(() => newCar.Refuel(fuelToRefuel));
        }

        [Test]

        public void CarDriveMethod_ShouldDecease_FuelAmount()
        {
            double distance = 10;
            double fuleConsuption = 10;

            Car newCar = new Car("BMW", "X5", fuleConsuption, 100);
            newCar.Refuel(50);

            double fuelNeeded = (distance / 100) * fuleConsuption;
            double expectedFuelAmonut = newCar.FuelAmount - fuelNeeded;

            newCar.Drive(distance);
            double actualFuelAmonut = newCar.FuelAmount;

            Assert.AreEqual(expectedFuelAmonut, actualFuelAmonut);
        }

        [Test]

        public void CarDriveMethod_ShouldThrowException_IfFuelNeededIsGreaterThanFuelAmount()
        {
            double distance = 1000;
            double fuleConsuption = 10;

            Car newCar = new Car("BMW", "X5", fuleConsuption, 100);
            newCar.Refuel(5);

            Assert.Throws<InvalidOperationException>(() => newCar.Drive(distance));
        }
    }
}