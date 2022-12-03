using NUnit.Framework;
using System;
using System.Drawing;
using System.Xml.Linq;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        private Gym gym;

        [SetUp]
        public void SetUp()
        {
            string name = "TopFit";
            int size = 3;

            this.gym = new Gym(name, size);
        }

        [Test]
        public void Test_ConstructorShouldSetName()
        {
            string expectedName = "TopFit";
            string actualName = this.gym.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Test_ConstructorShouldSetCapacity()
        {
            int expectedSize = 3;
            int actualSize = this.gym.Capacity;
            

            Assert.AreEqual(expectedSize, actualSize);
        }

        [Test]
        public void Test_ConstructorShouldInitializeAthletes()
        {
            int expectedCount = 0;
            int actualCount = this.gym.Count;


            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_NamePropertySholdThrowException_IfValueIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(name, 5));
        }

        [TestCase(-1)]
        [TestCase(-35721)]
        [TestCase(int.MinValue)]
        public void Test_CapacityPropertySholdThrowException_IfValueIsLessThanZero(int size)
        {
            Assert.Throws<ArgumentException>(() => new Gym("Name", size));
        }

        [Test]
        public void Test_CountPropertyShouldReturnCount()
        {
            Athlete athlete1 = new Athlete("PeshoMilchev");
            Athlete athlete2 = new Athlete("MilchoGoshov");
            Athlete athlete3 = new Athlete("GoshoPeshev");

            this.gym.AddAthlete(athlete1);
            this.gym.AddAthlete(athlete2);
            this.gym.AddAthlete(athlete3);

            int expectedCount = 3;
            int actualCount = this.gym.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_AddAthleteShouldThrowException_IfGymIsFull()
        {
            Athlete athlete1 = new Athlete("PeshoMilchev");
            Athlete athlete2 = new Athlete("MilchoGoshov");
            Athlete athlete3 = new Athlete("GoshoPeshev");
            Athlete athlete4 = new Athlete("OnchoPeshev");

            this.gym.AddAthlete(athlete1);
            this.gym.AddAthlete(athlete2);
            this.gym.AddAthlete(athlete3);

            Assert.Throws<InvalidOperationException>(() => this.gym.AddAthlete(athlete4));
        }

        [Test]
        public void Test_AddAthleteShouldAddAthlete()
        {
            Athlete athlete1 = new Athlete("PeshoMilchev");
            this.gym.AddAthlete(athlete1);

            string expectedAthlete = "Active athletes at TopFit: PeshoMilchev";
            string actualAthlete = this.gym.Report();

            Assert.AreEqual(expectedAthlete, actualAthlete);
        }

        [Test]
        public void Test_RemoveAthleteMethodShouldRemoveAthlete()
        {
            Athlete athlete1 = new Athlete("PeshoMilchev");
            Athlete athlete2 = new Athlete("MilchoGoshov");
            this.gym.AddAthlete(athlete1);
            this.gym.AddAthlete(athlete2);

            this.gym.RemoveAthlete("PeshoMilchev");

            string expectedAthlete = "Active athletes at TopFit: MilchoGoshov";
            string actualAthlete = this.gym.Report();

            Assert.AreEqual(expectedAthlete, actualAthlete);
        }

        [Test]
        public void Test_RemoveAthleteMethodShouldThrowException_IfNoAthleteFound()
        {
            Athlete athlete1 = new Athlete("PeshoMilchev");
            Athlete athlete2 = new Athlete("MilchoGoshov");
            this.gym.AddAthlete(athlete1);
            this.gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() => this.gym.RemoveAthlete("GoshoMilchev"));
        }

        [Test]
        public void Test_InjureAthleteMethodShouldThrowException_IfNoAthleteFound()
        {
            Athlete athlete1 = new Athlete("PeshoMilchev");
            Athlete athlete2 = new Athlete("MilchoGoshov");
            this.gym.AddAthlete(athlete1);
            this.gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() => this.gym.InjureAthlete("GoshoMilchev"));
        }

        [Test]
        public void Test_InjureAthleteMethodShouldSetAthleteInjureToTrue()
        {
            Athlete athlete1 = new Athlete("PeshoMilchev");
            Athlete athlete2 = new Athlete("MilchoGoshov");
            this.gym.AddAthlete(athlete1);
            this.gym.AddAthlete(athlete2);

            Athlete IsInjuredAthlete = this.gym.InjureAthlete("PeshoMilchev");
            bool IsInjured = IsInjuredAthlete.IsInjured;

            Assert.IsTrue(IsInjured);
        }

        [Test]
        public void Test_InjureAthleteMethodShouldReturnAthlete()
        {
            Athlete expectedAthlete = new Athlete("PeshoMilchev");
            Athlete athlete2 = new Athlete("MilchoGoshov");
            this.gym.AddAthlete(expectedAthlete);
            this.gym.AddAthlete(athlete2);

            Athlete actualAthlete = this.gym.InjureAthlete("PeshoMilchev");

            Assert.AreEqual(expectedAthlete, actualAthlete);
        }

        [Test]
        public void Test_ReportMethodShouldReturnOnlyNotInjuredAthletes()
        {
            Athlete athlete1 = new Athlete("PeshoMilchev");
            Athlete athlete2 = new Athlete("MilchoGoshov");
            Athlete athlete3 = new Athlete("GoshoPeshev");

            this.gym.AddAthlete(athlete1);
            this.gym.AddAthlete(athlete2);
            this.gym.AddAthlete(athlete3);

            this.gym.InjureAthlete("MilchoGoshov");
            string expectedReport = $"Active athletes at TopFit: PeshoMilchev, GoshoPeshev";
            string actualReport = this.gym.Report();

            Assert.AreEqual(expectedReport, actualReport);
        }
    }
}
