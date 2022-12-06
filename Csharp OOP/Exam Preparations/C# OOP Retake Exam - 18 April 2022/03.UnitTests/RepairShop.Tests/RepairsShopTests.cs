using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    [TestFixture]
    public class Tests
    {
        public class RepairsShopTests
        {
            private Garage garage;

            [SetUp]
            public void SetUp()
            {
                string name = "Service";
                int mechanicsAvailable = 5;
                this.garage = new Garage(name, mechanicsAvailable);
            }

            [Test]
            public void Test_ConstructorShouldSetMechanicsAvailable()
            {
                string expectedName = "Service";
                string actualName = this.garage.Name;

                Assert.AreEqual(expectedName, actualName);
            }

            [Test]
            public void Test_ConstructorShouldSetName()
            {
                int expectedMechanicsAvailable = 5;
                int actualMechanicsAvailable = this.garage.MechanicsAvailable;

                Assert.AreEqual(expectedMechanicsAvailable, actualMechanicsAvailable);
            }

            [Test]
            public void Test_ConstructorShouldInitializeData()
            {
                int expectedCount = 0;
                int actualCount = this.garage.CarsInGarage;

                Assert.AreEqual(expectedCount, actualCount);
            }

            [TestCase(null)]
            [TestCase("")]
            public void Test_NamePropertySholdthrowExceptionIfValueIsNullOrEmpty(string name)
            {
                Assert.Throws<ArgumentNullException>(() => new Garage(name, 3));
            }

            [TestCase(-75926)]
            [TestCase(-1)]
            [TestCase(int.MinValue)]
            [TestCase(0)]

            public void Test_MechanicsAvailablePropertySholdthrowExceptionIfValueIsZeroOrNegative(int mechanicsAvailable)
            {
                Assert.Throws<ArgumentException>(() => new Garage("Service", mechanicsAvailable));
            }

            [Test]
            public void Test_CarsInGaragePropertyShouldReturnCount()
            {
                Car car1 = new Car("BMW", 1);
                Car car2 = new Car("VW", 2);
                Car car3 = new Car("Opel", 3);

                this.garage.AddCar(car1);
                this.garage.AddCar(car2);
                this.garage.AddCar(car3);

                int expectedCount = 3;
                int actualCount = this.garage.CarsInGarage;

                Assert.AreEqual(expectedCount, actualCount);
            }


            [Test]
            public void Test_AddCarMethodShouldThrowExceptionIfNoMechanicsAvailable()
            {
                Car car1 = new Car("BMW", 1);
                Car car2 = new Car("VW", 2);
                Car car3 = new Car("Opel", 3);
                Car car4 = new Car("Mazda", 4);
                Car car5 = new Car("Nisan", 5);
                Car car6 = new Car("MG", 6);

                this.garage.AddCar(car1);
                this.garage.AddCar(car2);
                this.garage.AddCar(car3);
                this.garage.AddCar(car4);
                this.garage.AddCar(car5);

                Assert.Throws<InvalidOperationException>(() => this.garage.AddCar(car6));
            }

            [Test]
            public void Test_FixCarMethodShouldThrowExceptionIfCarNotFound()
            {

                Car car1 = new Car("BMW", 1);
                Car car2 = new Car("VW", 2);

                this.garage.AddCar(car1);
                this.garage.AddCar(car2);

                Assert.Throws<InvalidOperationException>(() => this.garage.FixCar("Opel"));
            }

            [Test]
            public void Test_FixCarMethodShouldReturnCarFixed()
            {
                Car car1 = new Car("BMW", 1);
                Car car2 = new Car("VW", 2);

                this.garage.AddCar(car1);
                this.garage.AddCar(car2);

                int expectedIssues = 0;
                this.garage.FixCar("VW");
                int actualIssues = car2.NumberOfIssues;

                Assert.AreEqual(expectedIssues, actualIssues);
            }

            [Test]
            public void Test_RemoveFixedCarShouldThrowExceptionIfNoFixedCars()
            {
                Car car1 = new Car("BMW", 1);
                Car car2 = new Car("VW", 2);
                Car car3 = new Car("Opel", 3);

                this.garage.AddCar(car1);
                this.garage.AddCar(car2);
                this.garage.AddCar(car3);

                Assert.Throws<InvalidOperationException>(() => this.garage.RemoveFixedCar());
            }

            [Test]
            public void Test_RemoveFixedCarShouldRemoveCars()
            {
                Car car1 = new Car("BMW", 1);
                Car car2 = new Car("VW", 2);
                Car car3 = new Car("Opel", 3);
                Car car4 = new Car("Mazda", 4);
                Car car5 = new Car("Nisan", 5);

                this.garage.AddCar(car1);
                this.garage.AddCar(car2);
                this.garage.AddCar(car3);
                this.garage.AddCar(car4);
                this.garage.AddCar(car5);

                this.garage.FixCar("Opel");
                this.garage.FixCar("VW");

                int expectedFixedCars = 2;
                int expactedCarsLeft = 3;
                int actualFixedCars = this.garage.RemoveFixedCar();
                int actulaCarsLeft = this.garage.CarsInGarage;

                Assert.AreEqual(expectedFixedCars, actualFixedCars);
                Assert.AreEqual(expactedCarsLeft, actulaCarsLeft);
            }

            [Test]
            public void Test_ReportsSholdreturnString()
            {
                Car car1 = new Car("BMW", 1);
                Car car2 = new Car("VW", 2);
                Car car3 = new Car("Opel", 3);
                Car car4 = new Car("Mazda", 4);
                Car car5 = new Car("Nisan", 5);

                this.garage.AddCar(car1);
                this.garage.AddCar(car2);
                this.garage.AddCar(car3);
                this.garage.AddCar(car4);
                this.garage.AddCar(car5);

                this.garage.FixCar("Opel");
                this.garage.FixCar("VW");

                string expectedReport = "There are 3 which are not fixed: BMW, Mazda, Nisan.";
                string actualReport = this.garage.Report();

                Assert.AreEqual(expectedReport, actualReport);
            }
        }
    }
}