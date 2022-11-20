using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private int health;
        private int experience;
        private int atackPoints;
        private Dummy dummy;

        [SetUp]
        public void SetUp_DummyTests()
        {
            this.health = 10;
            this.experience = 10;
            this.dummy = new Dummy(this.health, this.experience);
        }
        
        [Test]
        public void Test_DummyConstructor_ShouldSetData()
        {
            Assert.AreEqual(this.health, dummy.Health);
        }

        [Test]

        public void Test_DummyShouldLooseHealth_AfterAttack()
        {
            this.atackPoints = 2;
            this.dummy.TakeAttack(atackPoints);

            Assert.AreEqual(this.health - atackPoints, this.dummy.Health);
        }

        [Test]

        public void Test_DummyShouldThtowExeption_IfHealthIsZero()
        {
            this.atackPoints = 10;
            dummy.TakeAttack(atackPoints);

            Assert.Throws<InvalidOperationException> (() => dummy.TakeAttack(atackPoints));
        }

        [Test]

        public void Test_DummyShouldThtowExeption_IfHealthBelowZero()
        {
            this.atackPoints = 15;
            dummy.TakeAttack(atackPoints);

            Assert.Throws<InvalidOperationException>(() => this.dummy.TakeAttack(atackPoints));
        }

        [Test]

        public void Test_DummyShouldGiveExpireince_IfDead()
        {
            this.atackPoints = 15;
            dummy.TakeAttack(atackPoints);

            Assert.AreEqual(this.experience, this.dummy.GiveExperience());
        }

        [Test]

        public void Test_DummyGiveExpireince_ShouldThrowExeption_IfAlive()
        {

            Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience());
        }
    }
}