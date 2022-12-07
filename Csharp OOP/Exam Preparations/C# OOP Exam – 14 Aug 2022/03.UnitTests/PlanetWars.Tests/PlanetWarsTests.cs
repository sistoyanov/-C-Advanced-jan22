using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void Test_WeaponConstructorShouldSetName()
            {
                string expectedName = "AK47";
                Weapon weapon = new Weapon(expectedName, 120.0, 200);
                string actualName = weapon.Name;

                Assert.AreEqual(expectedName, actualName);
            }

            [Test]
            public void Test_WeaponConstructorShouldSetPrice()
            {
                double expectedPrice = 120.0;
                Weapon weapon = new Weapon("AK47", expectedPrice, 200);
                double actualPrice = weapon.Price;

                Assert.AreEqual(expectedPrice, actualPrice);
            }

            [Test]
            public void Test_WeaponConstructorShouldSetDestructionLevel()
            {
                int expectedDestructionLevel = 200;
                Weapon weapon = new Weapon("AK47", 120.0, expectedDestructionLevel);
                int actualDestructionLevel = weapon.DestructionLevel;

                Assert.AreEqual(expectedDestructionLevel, actualDestructionLevel);
            }

            [TestCase(-1.0)]
            [TestCase(-437828.0)]
            [TestCase(double.MinValue)]
            public void Test_WeaponPricePropertyShouldThrowExceptionIfPriceIsBelowZero(double price)
            {
                Assert.Throws<ArgumentException>(() => new Weapon("AK47", price, 200));
            }

            [Test]
            public void Test_WeaponIncreaseDestructionLevelMethodShouldIncreaseDestructionLevel()
            {
                Weapon weapon = new Weapon("AK47", 120.0, 200);
                weapon.IncreaseDestructionLevel();
                int expectedDestructionLevel = 201;
                int actualDestructionLevel = weapon.DestructionLevel;

                Assert.AreEqual(expectedDestructionLevel, actualDestructionLevel);
            }

            [TestCase(10)]
            [TestCase(235)]
            public void Test_WeaponIsNuclearMethodShouldRetunTrueIfDestructionLevelIsThenOrHigher(int destructionLevel)
            {
                Weapon weapon = new Weapon("AK47", 120.0, destructionLevel);
                Assert.IsTrue(weapon.IsNuclear);
            }

            [TestCase(9)]
            [TestCase(3)]
            public void Test_WeaponIsNuclearMethodShouldRetunTrueIfDestructionLevelIsBelowThen(int destructionLevel)
            {
                Weapon weapon = new Weapon("AK47", 120.0, destructionLevel);
                Assert.IsFalse(weapon.IsNuclear);
            }

            [Test]
            public void Test_PlanetConstructorShouldSetName()
            {
                string expectedName = "Planet";
                Planet planet = new Planet(expectedName, 567.0);
                string actualName = planet.Name;

                Assert.AreEqual(expectedName, actualName);
            }

            [Test]
            public void Test_PlanetConstructorShouldSetBudget()
            {
                double expectedBudget = 567.0;
                Planet planet = new Planet("Planet", expectedBudget);
                double actualBudget = planet.Budget;

                Assert.AreEqual(expectedBudget, actualBudget);
            }

            [Test]
            public void Test_PlanetConstructorShouldInitializeWeaponList()
            {
                Planet planet = new Planet("Planet", 567.0);
                int expectedCount = 0;
                int actualCount = planet.Weapons.Count;

                Assert.AreEqual(expectedCount, actualCount);
            }

            [TestCase(null)]
            [TestCase("")]
            public void Test_PlanetNamePropertyShouldThrowExceptionIfNameIsNullOrEmpty(string name)
            {
                Assert.Throws<ArgumentException>(() => new Planet(name, 567.0));
            }

            [TestCase(-1.0)]
            [TestCase(-437828.0)]
            [TestCase(double.MinValue)]
            public void Test_PlanetBudgetPropertyShouldThrowExceptionIfBudgetIsBelowZero(double budget)
            {
                Assert.Throws<ArgumentException>(() => new Planet("Planet", budget));
            }


            [Test]
            public void Test_PlanetWeaponsPropertyShouldRetunIReadOnlyCollection()
            {
                Weapon weapon1 = new Weapon("AK47", 120.0, 200);
                Weapon weapon2 = new Weapon("Bazuka", 1120.0, 800);
                Planet planet = new Planet("Planet", 567.0);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                IReadOnlyCollection<Weapon> expectedCollection = new List<Weapon> { weapon1, weapon2 };
                IReadOnlyCollection<Weapon> actualCollection = planet.Weapons;

                CollectionAssert.AreEqual(expectedCollection, actualCollection);
            }

            [Test]
            public void Test_PlanetMilitaryPowerRatioPropertyShouldRetunMilitaryPowerRatio()
            {
                Weapon weapon1 = new Weapon("AK47", 120.0, 200);
                Weapon weapon2 = new Weapon("Bazuka", 1120.0, 800);
                Planet planet = new Planet("Planet", 567.0);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                double expectedMilitaryPowerRatio = 200d + 800d;
                double actualMilitaryPowerRatio = planet.MilitaryPowerRatio;

                Assert.AreEqual(expectedMilitaryPowerRatio, actualMilitaryPowerRatio);
            }

            [Test]
            public void Test_PlanetProfitMethodShouldIncreaceBudget()
            {
                Planet planet = new Planet("Planet", 567.0);
                planet.Profit(123.0);

                double expectedBudget = 567.0 + 123.0;
                double actualBudget = planet.Budget;

                Assert.AreEqual(expectedBudget, actualBudget);
            }

            [Test]
            public void Test_PlanetSpendFundsMethodShouldDecreaseBudget()
            {
                Planet planet = new Planet("Planet", 567.0);
                planet.SpendFunds(123.0);

                double expectedBudget = 567.0 - 123.0;
                double actualBudget = planet.Budget;

                Assert.AreEqual(expectedBudget, actualBudget);
            }

            [Test]
            public void Test_PlanetSpendFundsMethodShouldThrowExceptionIfAmauntIsGreaterThanBudget()
            {
                Planet planet = new Planet("Planet", 567.0);
                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(2123.0));
            }

            [Test]
            public void Test_PlanetAddWeaponMethodShouldThrowExceptionIfWeaponExists()
            {
                Planet planet = new Planet("Planet", 567.0);
                Weapon weapon1 = new Weapon("AK47", 120.0, 200);
                Weapon weapon2 = new Weapon("Bazuka", 1120.0, 800);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon1));
            }

            [Test]
            public void Test_PlanetRemoveWeaponMethodShouldRemoveWeaponIfWeaponExists()
            {
                Planet planet = new Planet("Planet", 567.0);
                Weapon weapon1 = new Weapon("AK47", 120.0, 200);
                Weapon weapon2 = new Weapon("Bazuka", 1120.0, 800);
                Weapon weapon3 = new Weapon("RPG", 3220.0, 2100);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);

                planet.RemoveWeapon("Bazuka");

                IReadOnlyCollection<Weapon> expectedCollection = new List<Weapon> { weapon1, weapon3 };
                IReadOnlyCollection<Weapon> actualCollection = planet.Weapons;

                CollectionAssert.AreEqual(expectedCollection, actualCollection);
            }

            [Test]
            public void Test_PlanetUpgradeWeaponMethodShouldThrowExceptionIfWeaponNotExists()
            {
                Planet planet = new Planet("Planet", 567.0);
                Weapon weapon1 = new Weapon("AK47", 120.0, 200);
                Weapon weapon2 = new Weapon("Bazuka", 1120.0, 800);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("RPG"));
            }

            [Test]
            public void Test_PlanetUpgradeWeaponMethodShouldIncreaseWeaponDestructionLevel()
            {
                Planet planet = new Planet("Planet", 567.0);
                Weapon weapon1 = new Weapon("AK47", 120.0, 200);

                planet.AddWeapon(weapon1);
                int expectedDestructionLevel = 200 + 1;

                planet.UpgradeWeapon("AK47");
                int actualDestructionLevel = weapon1.DestructionLevel;

                Assert.AreEqual(expectedDestructionLevel, actualDestructionLevel);
            }

            [Test]
            public void Test_PlanetDestructOpponentMethodShouldThrowExceptionIfOpponentIsTooStrong()
            {
                Planet planet = new Planet("Planet", 567.0);
                Planet planet2 = new Planet("Planet2", 1567.0);

                Weapon weapon1 = new Weapon("AK47", 120.0, 200);
                Weapon weapon2 = new Weapon("Bazuka", 1120.0, 800);
                Weapon weapon3 = new Weapon("RPG", 3220.0, 2100);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                planet2.AddWeapon(weapon1);
                planet2.AddWeapon(weapon2);
                planet2.AddWeapon(weapon3);

                Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(planet));
            }

            [Test]
            public void Test_PlanetDestructOpponentMethodShouldReturnString()
            {
                Planet planet = new Planet("Planet", 567.0);
                Planet planet2 = new Planet("Planet2", 1567.0);

                Weapon weapon1 = new Weapon("AK47", 120.0, 200);
                Weapon weapon2 = new Weapon("Bazuka", 1120.0, 800);
                Weapon weapon3 = new Weapon("RPG", 3220.0, 2100);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);

                planet2.AddWeapon(weapon1);
                planet2.AddWeapon(weapon2);

                string expectedOutput = "Planet2 is destructed!";
                string actualOutput = planet.DestructOpponent(planet2);

                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
    }
}
