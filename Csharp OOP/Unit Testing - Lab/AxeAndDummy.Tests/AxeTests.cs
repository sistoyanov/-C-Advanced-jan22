using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        private int attackPoints;
        private int durabilityPoints;

        [SetUp]
        public void SetUp_AxeTests()
        {
            this.attackPoints = 10;
            this.durabilityPoints = 10;
            this.axe = new Axe(this.attackPoints, this.durabilityPoints);
            this.dummy = new Dummy(10, 10);
        }

        [Test]
        public void Test_AxeConstructorShouldSetData()
        {
            Assert.AreEqual(this.attackPoints,axe.AttackPoints);
            Assert.AreEqual(this.durabilityPoints,axe.DurabilityPoints);
        }
        
        [Test]
        public void Test_AxeLoosesDurabilityAfterAttack()
        {
            int expectedPointsAfterAttack = 9;
            this.axe.Attack(dummy);

            Assert.AreEqual(axe.DurabilityPoints, expectedPointsAfterAttack, "Axe Durability dosen't cjange after attack.");
        }

        [Test]

        public void Test_Throw_AxeIsBroken_IfDurabilityIsZero()
        {
            this.axe = new Axe(this.attackPoints, 0);
  
            Assert.Throws<InvalidOperationException>(() => this.axe.Attack(dummy));
        }

        [Test]

        public void Test_Throw_AxeIsBroken_IfDurabilityBelowZero()
        {
            this.axe = new Axe(this.attackPoints, -1);

            Assert.Throws<InvalidOperationException>(() => this.axe.Attack(dummy));
        }
    }
}