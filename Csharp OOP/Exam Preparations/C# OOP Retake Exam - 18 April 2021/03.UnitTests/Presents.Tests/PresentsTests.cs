namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            this.bag = new Bag();
        }
        
        [Test]
        public void Test_ConstructorShouldInitializeData()
        {
            IReadOnlyCollection<Present> expectedCollection = new List<Present>();
            IReadOnlyCollection<Present> actualCollection = this.bag.GetPresents();

            CollectionAssert.AreEqual(actualCollection, expectedCollection);
        }

        [Test]
        public void Test_CreateMethodShouldAddPresent()
        {
            Present present = new Present("Axe", 15);
            this.bag.Create(present);

            Assert.AreEqual(1, this.bag.GetPresents().Count);
        }

        [Test]
        public void Test_CreateMethodShouldThrowException_IfPesentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.bag.Create(null));
        }

        [Test]
        public void Test_CreateMethodShouldThrowException_IfPesentAlreadyExists()
        {
            Present present1 = new Present("Axe", 15);
            Present present2 = new Present("AUX", 45);
            this.bag.Create(present1);
            this.bag.Create(present2);

            Assert.Throws<InvalidOperationException>(() => this.bag.Create(present1));
        }

        [Test]
        public void Test_CreateMethodShouldReturnString()
        {
            Present present = new Present("Axe", 15);

            string expectedString = "Successfully added present Axe.";
            string actualString = this.bag.Create(present);

            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void Test_RemoveMethodShouldReturnTrue_IfRemoved()
        {
            Present present1 = new Present("Axe", 15);
            Present present2 = new Present("AUX", 45);
            this.bag.Create(present1);
            this.bag.Create(present2);

            Assert.IsTrue(this.bag.Remove(present2));
        }

        [Test]
        public void Test_RemoveMethodShouldReturnFalse_IfNotRemoved()
        {
            Present present1 = new Present("Axe", 15);
            Present present2 = new Present("AUX", 45);
            Present present3 = new Present("Ball", 234);
            this.bag.Create(present1);
            this.bag.Create(present2);

            Assert.IsFalse(this.bag.Remove(present3));
        }

        [Test]
        public void Test_GetPresentWithLeastMagicMethod_ShouldReturnPresentCorretlly()
        {
            Present expectedPresent = new Present("Axe", 15);
            Present present2 = new Present("AUX", 45);
            Present present3 = new Present("Ball", 234);

            this.bag.Create(expectedPresent);
            this.bag.Create(present2);
            this.bag.Create(present3);

            Present actualPresent = this.bag.GetPresentWithLeastMagic();

            Assert.AreEqual(expectedPresent, actualPresent);
        }

        [Test]
        public void Test_GetPresentWithLeastMagicMethod_ShouldThrowException_IfCollectionEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => this.bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void Test_GetPresentMethod_ShouldReturnPresentCorretlly()
        {
            Present present1 = new Present("Axe", 15);
            Present expectedPresent = new Present("AUX", 45);
            Present present3 = new Present("Ball", 234);

            this.bag.Create(present1);
            this.bag.Create(expectedPresent);
            this.bag.Create(present3);

            Present actualPresent = this.bag.GetPresent("AUX");

            Assert.AreEqual(expectedPresent, actualPresent);
        }

        [Test]
        public void Test_GetPresentMethod_ShouldReturnNull_IfPresentnOTFound()
        {
            Present present1 = new Present("Axe", 15);
            Present present3 = new Present("Ball", 234);

            this.bag.Create(present1);
            this.bag.Create(present3);

            Present actualPresent = this.bag.GetPresent("AUX");

            Assert.IsNull(actualPresent);

        }

        [Test]
        public void Test_GetPresentsMethod_ShouldReturnIReadOnlyCollection()
        {
            Present present1 = new Present("Axe", 15);
            Present present2 = new Present("AUX", 45);
            Present present3 = new Present("Ball", 234);

            IReadOnlyCollection<Present> expectedCollection = new List<Present> { present1, present2, present3};

            this.bag.Create(present1);
            this.bag.Create(present2);
            this.bag.Create(present3);

            IReadOnlyCollection<Present> actualCollection = this.bag.GetPresents();

            CollectionAssert.AreEqual(actualCollection, expectedCollection);
        }
    }
}
