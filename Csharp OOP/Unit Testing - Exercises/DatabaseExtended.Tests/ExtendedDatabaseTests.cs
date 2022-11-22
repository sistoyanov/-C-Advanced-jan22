namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;


    [TestFixture]
    public class DatabaseExtendedTests
    {
        private const int DatabaseCapacity = 16;

        private Person[] persons;
        private Database database;

        [SetUp]

        public void SetUp_DataBaseTests()
        {

             persons = new Person[DatabaseCapacity];

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, "Test" + i);
            }

            this.database = new Database(persons);
        }

        [Test]

        public void Test_DataBaseConstructor_ShouldSetData()
        {

            Assert.AreEqual(DatabaseCapacity, this.database.Count); 
        }

        [Test]

        public void Test_DataBaseAddRange_ShouldThrowExeption_IfDataBaseCountIsMoreThan16()
        {
            var personsTest = new Person[17];
           
            Assert.Throws<ArgumentException>(() => this.database = new Database(personsTest));

        }

        [Test]

        public void Test_DataBaseAdd_ShouldThrowExeption_IfDataBaseCountIs16()
        {

            Person person = new Person(23, "Test");
            Assert.Throws<InvalidOperationException>(() => this.database.Add(person));
        }

        [Test]

        public void Test_DataBaseAdd_ShouldThrowExeption_IfUserNameExists()
        {

            this.database.Remove();
            Person person = new Person(1345, "Test1");
            Assert.Throws<InvalidOperationException>(() => this.database.Add(person));
        }


        [Test]

        public void Test_DataBaseAdd_ShouldThrowExeption_IfPersonIdExists() 
        {

            this.database.Remove();
            Person person = new Person(13, "SDRF");
            Assert.Throws<InvalidOperationException>(() => this.database.Add(person));
        }

        [Test]

        public void Test_DataBaseAdd_ShouldAddPerson_Properlly()
        {
            this.database = new Database();
            Person person = new Person(1345, "Test1");
            this.database.Add(person);

            Assert.AreEqual(1, database.Count);
        }



        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Tets_FindByUserName_ShouldThrowException_IfTheNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(name));
        }

        [Test]
        public void Test_FindByUserName_ShouldThrowException_IfUserNameDoesNotExists()
        {
            Database newDatabase = new Database(new Person(1, "Pesho"));
            Assert.Throws<InvalidOperationException>(() => newDatabase.FindByUsername("Desi"));
        }


        [Test]

        public void Test_DataBaseFindByUsername_ShouldReturnPerson() 
        {
            string name = "Test1";
            Person person = this.database.FindByUsername(name);
            Assert.AreEqual(name, person.UserName);
        }

        [Test]

        public void Test_DataBaseFindId_ShouldReturnPerson()
        {
            long id = 1;
            Person person = this.database.FindById(id);
            Assert.AreEqual(id, person.Id);
        }


        [TestCase(long.MinValue)]
        [TestCase(-2233556)]
        [TestCase(-1)]
        public void Test_FindByUserId_ShouldThrowException_IfIdIsLessThanZero(long Id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(Id));
        }

        [TestCase(long.MaxValue)]
        [TestCase(2646)]
        
        public void Test_FindByUserID_ShouldThrowException_IfIdDoesntExist(long Id)
        {
            Database newDatabase = new Database(new Person(1, "Pesho"));
            Assert.Throws<InvalidOperationException>(() => newDatabase.FindById(Id));
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

            Assert.AreEqual(DatabaseCapacity - 1, database.Count);
        }


    }

}
