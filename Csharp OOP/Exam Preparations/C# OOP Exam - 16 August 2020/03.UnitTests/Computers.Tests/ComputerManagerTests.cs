using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {
        private ComputerManager computerManager;

        [SetUp]
        public void Setup()
        {
            this.computerManager = new ComputerManager();
        }

        [Test]
        public void Test_ComputerManagerConstructor_ShouldInitialize_CoputerList()
        {
            Assert.IsNotNull(this.computerManager.Computers);
        }

        [Test]
        public void Test_ComputerManagerCount_ShouldReturn_CoputerCount()
        {
            Computer newComputer = new Computer("Lenovo", "X1", 2300);
            this.computerManager.AddComputer(newComputer);

            int expectedCoumputerCount = 1;
            int actualCoumputerCount = this.computerManager.Count;

            Assert.AreEqual(expectedCoumputerCount, actualCoumputerCount);
        }

        [Test]
        public void Test_ComputerManagerAddMethod_ShouldThrowException_IfCoputerAlreadyExists()
        {
            Computer newComputer = new Computer("Lenovo", "X1", 2300);
            this.computerManager.AddComputer(newComputer);

            Assert.Throws<ArgumentException>(() => this.computerManager.AddComputer(newComputer));
        }

        [Test]
        public void Test_ComputerManagerAddMethod_ShouldAddComputerCorrectly()
        {
            string manufacturer = "Lenovo";
            string model = "X1";

            Computer expectedComputer = new Computer(manufacturer, model, 2300);
            this.computerManager.AddComputer(expectedComputer);

            Computer actualComputer = this.computerManager.GetComputer(manufacturer, model);

            Assert.AreEqual(expectedComputer, actualComputer);
        }

        [Test]
        public void Test_ComputerManagerRemoveMethod_ShouldRemoveComputerCorrectly()
        {
            string manufacturer = "Lenovo";
            string model = "X1";

            Computer expectedComputerToRemove = new Computer(manufacturer, model, 2300);
            this.computerManager.AddComputer(expectedComputerToRemove);

            Computer actualRemovedComputer = this.computerManager.RemoveComputer(manufacturer, model);

            Assert.AreEqual(expectedComputerToRemove, actualRemovedComputer);
        }

        [Test]
        public void Test_ComputerManagerGetComputerMethod_ShouldReturnComputerCorectly()
        {
            string manufacturer = "Lenovo";
            string model = "X1";

            Computer expectedComputer = new Computer(manufacturer, model, 2300);
            this.computerManager.AddComputer(expectedComputer);

            Computer actualComputer = this.computerManager.GetComputer(manufacturer, model);

            Assert.AreEqual(expectedComputer, actualComputer);
        }


        [Test]
        public void Test_ComputerManagerGetComputerMethod_ShouldThrowException_IfComputer_ManufacturerNotExist()
        {
            Computer newComputer = new Computer("Lenovo", "X1", 2300);
            this.computerManager.AddComputer(newComputer);

            Assert.Throws<ArgumentException>(() => this.computerManager.GetComputer("Ibm", "ThinkPad"));
        }

        [Test]
        public void Test_ComputerManagerGetComputerMethod_ShouldThrowException_IfComputer_ModelNotExists()
        {
            Computer newComputer = new Computer("Lenovo", "X1", 2300);
            this.computerManager.AddComputer(newComputer);

            Assert.Throws<ArgumentException>(() => this.computerManager.GetComputer("Lenovo", "ThinkPad"));
        }

        [Test]
        public void Test_ComputerManagerGetComputersByManufacturerMethod_ShouldReturnCollectionOfComputers()
        {
            string manufactorer1 = "Lenovo";
            string manufactorer2 = "IBM";
            Computer c1 = new Computer(manufactorer1, "X1", 2300);
            Computer c2 = new Computer(manufactorer1, "Think", 2800);
            Computer c3 = new Computer(manufactorer2, "ThinkPad", 3800);
            Computer c4 = new Computer(manufactorer2, "Pad", 7800);
            Computer c5 = new Computer(manufactorer2, "ThinkPad89", 1800);

            this.computerManager.AddComputer(c1);
            this.computerManager.AddComputer(c2);
            this.computerManager.AddComputer(c3);
            this.computerManager.AddComputer(c4);
            this.computerManager.AddComputer(c5);

            List<Computer> expectedCollection = new List<Computer> { c1, c2 };
            List<Computer> actualCollection = this.computerManager.GetComputersByManufacturer(manufactorer1).ToList();

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void ValidateNullValueShouldWurkCorrectly()
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.RemoveComputer(null, null));
            Assert.Throws<ArgumentNullException>(() => this.computerManager.AddComputer(null));
            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputersByManufacturer(null));
        }
    }
}