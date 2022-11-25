using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry race;

        [SetUp]
        public void Setup()
        {
            this.race = new RaceEntry();
        }

        [Test]  // not working correctlly should use reflection to test
        public void Test_RaceEntryConstructor_ShouldInitializeCorrectlly()
        {
            Assert.IsNotNull(race);
        }

        [Test]
        public void Test_RaceEntryCounterProperty_ShouldReturnDriverCount()
        {
            UnitCar car = new UnitCar("BMW", 120, 2500.0);
            UnitDriver driver = new UnitDriver("Pesho", car);
            int expectedDriverCount = 1;

            this.race.AddDriver(driver);
            int actualDriverCount = this.race.Counter;

            Assert.AreEqual(expectedDriverCount, actualDriverCount);
        }

        [Test]
        public void Test_RaceEntryAddDriverMethod_ShouldThrowException_IfDriverIsNull()
        {
            UnitCar car = new UnitCar("BMW", 120, 2500.0);
            UnitDriver driver = null;

            Assert.Throws<InvalidOperationException>(() => this.race.AddDriver(driver));
        }

        [Test]
        public void Test_RaceEntryAddDriverMethod_ShouldThrowException_IfDriverExists()
        {
            UnitCar car = new UnitCar("BMW", 120, 2500.0);
            UnitDriver driver = new UnitDriver("Pesho", car);

            this.race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => this.race.AddDriver(driver));
        }

        [Test]
        public void Test_RaceEntryAddDriverMethod_ShouldThrowException_IfDriverNameIsNull()
        {
            UnitCar car = new UnitCar("BMW", 120, 2500.0);

            Assert.Throws<ArgumentNullException>(() => new UnitDriver(null, car));
        }

        [Test]
        public void Test_RaceEntryAddDriverMethod_ShouldReturnMessageCorrectly()
        {
            UnitCar car = new UnitCar("BMW", 120, 2500.0);
            UnitDriver driver = new UnitDriver("Pesho", car);

            string expectedResult = "Driver Pesho added in race.";
            string actualResult = this.race.AddDriver(driver);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test_RaceEntryCalculateAverageHorsePowerMethod_ShouldThrowException_IfDriverCountIsLessThanMinParticipants()
        {
            UnitCar car = new UnitCar("BMW", 120, 2500.0);
            UnitDriver driver = new UnitDriver("Pesho", car);

            this.race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => this.race.CalculateAverageHorsePower());
        }

        [Test]
        public void Test_RaceEntryCalculateAverageHorsePowerMethod_CalculateAndReturn_AverageHorsePowerCorrectly()
        {
            UnitCar car1 = new UnitCar("BMW", 120, 2500.0);
            UnitDriver driver1 = new UnitDriver("Pesho", car1);

            UnitCar car2 = new UnitCar("VW", 150, 1500.0);
            UnitDriver driver2 = new UnitDriver("Gosho", car2);

            UnitCar car3 = new UnitCar("Ford", 100, 1000.0);
            UnitDriver driver3 = new UnitDriver("Misho", car3);

            this.race.AddDriver(driver1);
            this.race.AddDriver(driver2);
            this.race.AddDriver(driver3);

            double expectedAvarageHorsePower = (car1.HorsePower + car2.HorsePower + car3.HorsePower) / (double)this.race.Counter;
            double actualAvarageHorsePower = this.race.CalculateAverageHorsePower();

            Assert.AreEqual(expectedAvarageHorsePower, actualAvarageHorsePower);
        }
    }
}