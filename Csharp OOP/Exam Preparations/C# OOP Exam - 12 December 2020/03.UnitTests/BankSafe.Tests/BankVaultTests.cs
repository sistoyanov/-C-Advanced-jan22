using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{ 
    public class BankVaultTests
    {
        BankVault bankVault;

        [SetUp]
        public void Setup()
        {
            this.bankVault = new BankVault();
        }

        [Test]
        public void Test_BankVaultConstructor_ShouldInitializeCorrectlly()
        {
            Assert.IsNotNull(bankVault.VaultCells);
        }

        [Test]
        public void Test_BankVaultValueCells_ShouldReturnValueCellsCollection()
        {
            IReadOnlyDictionary<string, Item> excpectedValueCells = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            IReadOnlyDictionary<string, Item> actualValueCells = this.bankVault.VaultCells;

            CollectionAssert.AreEqual(excpectedValueCells, actualValueCells);
        }

        [Test]
        public void Test_BankVaultAddItemMethod_ShouldThrowExeption_IfCellDoesntExists()
        {
            string cell = "D12";
            Item newItem = new Item("Gosho", "123");

            Assert.Throws<ArgumentException>(() => this.bankVault.AddItem(cell, newItem));
        }

        [Test]
        public void Test_BankVaultAddItemMethod_ShouldThrowExeption_IfCellIsTaken()
        {
            string cell1 = "A1";
            Item item1 = new Item("Gosho", "123");
            string cell2 = "A2";
            Item item2 = new Item("Pesho", "234");
            string cell3 = "A3";
            Item item3 = new Item("Tosho", "456");

            Item item4 = new Item("Misho", "789");

            this.bankVault.AddItem(cell1, item1);
            this.bankVault.AddItem(cell2, item2);
            this.bankVault.AddItem(cell3, item3);

            Assert.Throws<ArgumentException>(() => this.bankVault.AddItem(cell2, item4));
        }

        [Test]
        public void Test_BankVaultAddItemMethod_ShouldThrowExeption_IfItemIsAlreadyInCell()
        {
            string cell1 = "A1";
            Item item1 = new Item("Gosho", "123");
            string cell2 = "A2";
            Item item2 = new Item("Pesho", "234");
            string cell3 = "A3";
            Item item3 = new Item("Tosho", "456");

            string cell4 = "A4";

            this.bankVault.AddItem(cell1, item1);
            this.bankVault.AddItem(cell2, item2);
            this.bankVault.AddItem(cell3, item3);

            Assert.Throws<InvalidOperationException>(() => this.bankVault.AddItem(cell4, item3));
        }

        [Test]
        public void Test_BankVaultAddItemMethod_ShouldSetCellCorrectlly()
        {
            string cell1 = "A1";
            Item expectedItem = new Item("Gosho", "123");
            this.bankVault.AddItem(cell1, expectedItem);

            IReadOnlyDictionary<string, Item> actualValueCells = this.bankVault.VaultCells;

            Item actualItem = actualValueCells[cell1];

            Assert.AreEqual(expectedItem, actualItem);
        }

        [Test]
        public void Test_BankVaultAddItemMethod_ShouldReturnMessage()
        {
            string cell1 = "A1";
            Item item1 = new Item("Gosho", "123");
            string expectedString = $"Item:{item1.ItemId} saved successfully!";
            string actualString = this.bankVault.AddItem(cell1, item1);

            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void Test_BankVaultRemoveMethod_ShouldThrowExeption_IfCellDoesntExists()
        {
            string cell = "D12";
            Item newItem = new Item("Gosho", "123");

            Assert.Throws<ArgumentException>(() => this.bankVault.RemoveItem(cell, newItem));
        }

        [Test]
        public void Test_BankVaultRemoveMethod_ShouldThrowExeption_IfItemDoesntExists()
        {
            string cell = "A2";
            Item newItem = new Item("Gosho", "123");

            Assert.Throws<ArgumentException>(() => this.bankVault.RemoveItem(cell, newItem));
        }

        [Test]
        public void Test_BankVaultRemoveItemMethod_ShouldRemoveCellCorrectlly()
        {
            string cell1 = "A1";
            Item item1 = new Item("Gosho", "123");
            string cell2 = "A2";
            Item item2 = new Item("Pesho", "234");
            string cell3 = "A3";
            Item item3 = new Item("Tosho", "456");

            this.bankVault.AddItem(cell1, item1);
            this.bankVault.AddItem(cell2, item2);
            this.bankVault.AddItem(cell3, item3);

            this.bankVault.RemoveItem(cell2, item2);

            IReadOnlyDictionary<string, Item> actualValueCells = this.bankVault.VaultCells;

            Item actualItem = actualValueCells[cell2];

            Assert.AreEqual(null, actualItem);
        }

        [Test]
        public void Test_BankVaultRemoveItemMethod_ShouldReturnMessage()
        {
            string cell1 = "A1";
            Item item1 = new Item("Gosho", "123");
            string cell2 = "A2";
            Item item2 = new Item("Pesho", "234");
            string cell3 = "A3";
            Item item3 = new Item("Tosho", "456");

            this.bankVault.AddItem(cell1, item1);
            this.bankVault.AddItem(cell2, item2);
            this.bankVault.AddItem(cell3, item3);

            string expectedString = $"Remove item:{item3.ItemId} successfully!";
            string actualString = this.bankVault.RemoveItem(cell3, item3);

            Assert.AreEqual(expectedString, actualString);
        }
    }
}