using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Shop shop;

        [SetUp]
        public void SetUp()
        {
            int capacity = 5;
            this.shop = new Shop(capacity);
        }

        [Test]
        public void Test_CosnstructorShouldInitializeData()
        {
            int expectedCount = 0;
            int actualCount = this.shop.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_CosnstructorShouldSetCapacity()
        {
            int expectedCapacity = 5;
            int actualCapacity = this.shop.Capacity;

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }


        [TestCase(-1)]
        [TestCase(-86432)]
        [TestCase(int.MinValue)]
        public void Test_CapacityPropertyShouldThrowException_IfValueIsBelowZero(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Shop(capacity));
        }

        [Test]
        public void Test_CountPropertyShouldReturnCount()
        {
            Smartphone smartphone1 = new Smartphone("Nokia", 100);
            Smartphone smartphone2 = new Smartphone("LG", 80);
            Smartphone smartphone3 = new Smartphone("NEC", 53);

            this.shop.Add(smartphone1);
            this.shop.Add(smartphone2);
            this.shop.Add(smartphone3);

            int expectedCount = 3;
            int actualCount = this.shop.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_AddMethodShouldThrowExceptionIfPhoneNameExists()
        {
            Smartphone smartphone1 = new Smartphone("Nokia", 100);
            Smartphone smartphone2 = new Smartphone("LG", 80);
            Smartphone smartphone3 = new Smartphone("NEC", 53);
            Smartphone smartphone4 = new Smartphone("LG", 72);

            this.shop.Add(smartphone1);
            this.shop.Add(smartphone2);
            this.shop.Add(smartphone3);

            Assert.Throws<InvalidOperationException>(() => this.shop.Add(smartphone4));
        }

        [Test]
        public void Test_AddMethodShouldThrowExceptionIfNoCapacity()
        {
            Shop newShop = new Shop(3);
            Smartphone smartphone1 = new Smartphone("Nokia", 100);
            Smartphone smartphone2 = new Smartphone("LG", 80);
            Smartphone smartphone3 = new Smartphone("NEC", 53);
            Smartphone smartphone4 = new Smartphone("LG", 72);

            newShop.Add(smartphone1);
            newShop.Add(smartphone2);
            newShop.Add(smartphone3);

            Assert.Throws<InvalidOperationException>(() => newShop.Add(smartphone4));
        }

        [Test]
        public void Test_RemoveMethodShouldThrowExceptionIfNoPhoneFound()
        {
            Smartphone smartphone1 = new Smartphone("Nokia", 100);
            Smartphone smartphone2 = new Smartphone("LG", 80);
            Smartphone smartphone3 = new Smartphone("NEC", 53);

            this.shop.Add(smartphone1);
            this.shop.Add(smartphone2);
            this.shop.Add(smartphone3);

            Assert.Throws<InvalidOperationException>(() => this.shop.Remove("Apple"));
        }

        [Test]
        public void Test_RemoveMethodShouldRemovePhone()
        {
            Smartphone smartphone1 = new Smartphone("Nokia", 100);
            Smartphone smartphone2 = new Smartphone("LG", 80);
            Smartphone smartphone3 = new Smartphone("NEC", 53);

            this.shop.Add(smartphone1);
            this.shop.Add(smartphone2);
            this.shop.Add(smartphone3);

            this.shop.Remove("LG");

            int expectedCount = 2;
            int actualCount = this.shop.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_TestPhoneMethodShouldThrowExceptionIfNoPhoneFound()
        {
            Smartphone smartphone1 = new Smartphone("Nokia", 100);
            Smartphone smartphone2 = new Smartphone("LG", 80);
            Smartphone smartphone3 = new Smartphone("NEC", 53);

            this.shop.Add(smartphone1);
            this.shop.Add(smartphone2);
            this.shop.Add(smartphone3);

            Assert.Throws<InvalidOperationException>(() => this.shop.TestPhone("Apple", 20));
        }

        [Test]
        public void Test_TestPhoneMethodShouldThrowExceptionIfPhoneHasNoEnoughCharge()
        {
            Smartphone smartphone3 = new Smartphone("NEC", 53);
            this.shop.Add(smartphone3);

            Assert.Throws<InvalidOperationException>(() => this.shop.TestPhone("NEC", 60));
        }

        [Test]
        public void Test_TestPhoneMethodShouldDecreaceBatteryCharge()
        {
            Smartphone smartphone3 = new Smartphone("NEC", 100);
            this.shop.Add(smartphone3);
            this.shop.TestPhone("NEC", 45);

            int expectedCharge = 55;
            int actualCharge = smartphone3.CurrentBateryCharge;

            Assert.AreEqual(expectedCharge, actualCharge);
        }

        [Test]
        public void Test_TestChargePhoneMethodShouldThrowExceptionIfNoPhoneFound()
        {
            Smartphone smartphone1 = new Smartphone("Nokia", 100);
            Smartphone smartphone2 = new Smartphone("LG", 80);

            this.shop.Add(smartphone1);
            this.shop.Add(smartphone2);

            Assert.Throws<InvalidOperationException>(() => this.shop.ChargePhone("Apple"));
        }

        [Test]
        public void Test_TestChargePhoneMethodShouldChargePhone()
        {
            Smartphone smartphone1 = new Smartphone("Nokia", 100);
            this.shop.Add(smartphone1);

            this.shop.TestPhone("Nokia", 45);
            this.shop.ChargePhone("Nokia");

            int expectedCharge = 100;
            int actualCharge = smartphone1.CurrentBateryCharge;

            Assert.AreEqual(expectedCharge, actualCharge);
        }
    }
}