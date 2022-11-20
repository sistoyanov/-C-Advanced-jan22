namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        private int[] data;
        private int count;
        int[] arr;
        private Database database;
        
        [SetUp]

        public void SetUp_DataBase()
        {
            this.arr = Enumerable.Range(1, 16).ToArray();
            this.data = arr;
            this.count = arr.Length;
            this.database = new Database(data);
        }

        [Test]

        public void Test_DataBaseConstructor_ShouldSetData()
        {
            Assert.AreEqual(this.count, this.database.Count);
        }

        [Test]

        public void Test_DataBaseAdd_ShouldThrowExeption_IfDataBaseCountIs16()
        {
            int element = 1;

            Assert.Throws<InvalidOperationException> (() => this.database.Add(element));
        }

        [Test]

        public void Test_DataBaseRemove_ShouldThrowExeption_IfDataBaseIsEmpty()
        {
            this.database = new Database();

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]

        public void Test_DataBaseRemove_ShouldRemoveLastElement()
        {
            this.database.Remove();
            Assert.AreEqual(this.count - 1, database.Count);
            //Assert.AreEqual(0, this.database.);
        }

        [Test]

        public void Test_DataBaseFetch_ShouldReturnArray()
        {
            int[] copyArray = database.Fetch();

            Assert.AreEqual (this.arr, copyArray);
        }
    }
}
