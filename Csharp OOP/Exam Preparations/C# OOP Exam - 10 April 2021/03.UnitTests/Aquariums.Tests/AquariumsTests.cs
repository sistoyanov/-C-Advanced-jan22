namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void Test_Constructor_ShouldSetDataCorrectlly()
        {
            string expectedName = "New";
            int expectedCapacity = 12;

            Aquarium aquarium = new Aquarium(expectedName, expectedCapacity);

            string actualName = aquarium.Name;
            int actualCapacity = aquarium.Capacity;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [TestCase(null)]
        [TestCase("")]

        public void Test_NameProperty_ShouldThrowExeption_IfIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, 21));
        }

        [TestCase(-1)]
        [TestCase(int.MinValue)]
        [TestCase(-45782)]

        public void Test_CapacityProperty_ShouldThrowExeption_IfIsLessThanZero(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Name", capacity));
        }

        [Test]
        public void Test_CountProperty_ShouldReturnCountCorrectlly()
        {
            Aquarium aquarium = new Aquarium("Name", 45);
            Fish fish1 = new Fish("Misho");
            Fish fish2 = new Fish("Gisho");

            aquarium.Add(fish1);
            aquarium.Add(fish2);

            int expectedFishCount = 2;
            int actualFishCount = aquarium.Count;

            Assert.AreEqual(expectedFishCount, actualFishCount);
        }

        [Test]
        public void Test_AddFishMethod_ShouldThrowExeption_IfAquriumIsFull()
        {
            Aquarium aquarium = new Aquarium("Name", 3);

            Fish fish1 = new Fish("Misho");
            Fish fish2 = new Fish("Gisho");
            Fish fish3 = new Fish("Pisho");

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            Assert.Throws<InvalidOperationException> (() => aquarium.Add(fish1));
        }

        [Test]
        public void Test_RemoveFishMethod_ShouldThrowExeption_IfFishNotFound()
        {
            Aquarium aquarium = new Aquarium("Name", 5);

            Fish fish1 = new Fish("Misho");
            Fish fish2 = new Fish("Gisho");
            Fish fish3 = new Fish("Pisho");

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Disho"));
        }

        [Test]
        public void Test_RemoveFishMethod_ShouldRemoveFishCorrectlly()
        {
            Aquarium aquarium = new Aquarium("Name", 5);

            Fish fish1 = new Fish("Misho");
            Fish fish2 = new Fish("Gisho");
            Fish fish3 = new Fish("Pisho");

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            aquarium.RemoveFish("Gisho");
            int expectedFishCount = 2;
            int actualFishCount = aquarium.Count;

            Assert.AreEqual(expectedFishCount, actualFishCount);
        }

        [Test]
        public void Test_SellFishMethod_ShouldThrowExeption_IfFishNotFound()
        {
            Aquarium aquarium = new Aquarium("Name", 5);

            Fish fish1 = new Fish("Misho");
            Fish fish2 = new Fish("Gisho");
            Fish fish3 = new Fish("Pisho");

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Disho"));
        }

        [Test]
        public void Test_SellFishMethod_ShouldReturFishCorrectlly()
        {
            Aquarium aquarium = new Aquarium("Name", 5);

            Fish fish1 = new Fish("Misho");
            Fish expectedFish = new Fish("Gisho");
            Fish fish3 = new Fish("Pisho");

            aquarium.Add(fish1);
            aquarium.Add(expectedFish);
            aquarium.Add(fish3);

            Fish actualFish = aquarium.SellFish("Gisho");

            Assert.AreEqual(expectedFish, actualFish);
        }

        [Test]
        public void Test_SellFishMethod_ShouldSetFishAvailabilityToFalse()
        {
            Aquarium aquarium = new Aquarium("Name", 5);

            Fish fish1 = new Fish("Misho");
            Fish fish2 = new Fish("Gisho");
            Fish fish3 = new Fish("Pisho");

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            aquarium.SellFish("Misho");

            Assert.IsFalse(fish1.Available);
        }

        [Test]
        public void Test_ReportMethod_ShouldReturnStringCorrectlly()
        {
            Aquarium aquarium = new Aquarium("Name", 5);

            Fish fish1 = new Fish("Misho");
            Fish fish2 = new Fish("Gisho");
            Fish fish3 = new Fish("Pisho");

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            string expectdString = "Fish available at Name: Misho, Gisho, Pisho";
            string actualString = aquarium.Report();

            Assert.AreEqual(expectdString, actualString);
        }
    }
}
