namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Xml.Linq;

    [TestFixture]
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;

        [Test]

        public void WarriorConstructor_ShouldSetDataCorretlly()
        {
            string expectedName = "Pesho";
            int expectedDamage = 10;
            int expectedHp = 50;

            Warrior newWarrior = new Warrior(expectedName, expectedDamage, expectedHp);

            string actualName = newWarrior.Name;
            int actualDamage = newWarrior.Damage;
            int actualHp = newWarrior.HP;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDamage, actualDamage);
            Assert.AreEqual(expectedHp, actualHp);
        }

        [TestCase(null)]
        [TestCase("  ")]
        public void WarriorNameProperty_ShouldThrowException_IfNameIsNullOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 10, 100));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-25647)]
        [TestCase(int.MinValue)]
        public void WarriorDamageProperty_ShouldThrowException__IfItIsZeroOrBelow(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("BMW", damage, 100));
        }


        [TestCase(-1)]
        [TestCase(-25647)]
        [TestCase(int.MinValue)]
        public void WarriorHPProperty_ShouldThrowException__IfItIsBelowZero(int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("BMW", 10, hp));
        }

        [Test]

        public void WarriorAttackMethod_ShouldDecreace_AttackingWarriorHp()
        {
            Warrior attackingW = new Warrior("Pesho", 20, 100);
            Warrior defendingWarrior = new Warrior("Gosho", 10, 50);

            int expectedHp = attackingW.HP - defendingWarrior.Damage;

            attackingW.Attack(defendingWarrior);
            int actualHp = attackingW.HP;

            Assert.AreEqual(expectedHp, actualHp);
        }

        [Test]

        public void WarriorAttackMethod_ShouldDecreace_DefendingWarriorHp()
        {
            Warrior attackingW = new Warrior("Pesho", 20, 100);
            Warrior defendingW = new Warrior("Gosho", 10, 50);

            int expectedHp = defendingW.HP - attackingW.Damage;

            attackingW.Attack(defendingW);
            int actualHp = defendingW.HP;

            Assert.AreEqual(expectedHp, actualHp);
        }

        [Test]

        public void WarriorAttackMethod_ShouldDecreace_DefendingWarriorHpToZero_IfAttakingWariorDamage_IsGreaterThan_DefendingWarriorHp()
        {
            Warrior attackingW = new Warrior("Pesho", 80, 100);
            Warrior defendingW = new Warrior("Gosho", 10, 50);

            int expectedHp = 0;

            attackingW.Attack(defendingW);
            int actualHp = defendingW.HP;

            Assert.AreEqual(expectedHp, actualHp);
        }

        [TestCase (30)]
        [TestCase (15)]
        [TestCase (0)]

        public void WarriorAttackMethod_ShouldThrowException_IfAttackingWarriorHp_IsLessOrEqualTo_MIN_ATTACK_HP(int hp)
        {
            Warrior attackingW = new Warrior("Pesho", 30, hp);
            Warrior defendingW = new Warrior("Gosho", 10, 50);

            Assert.Throws<InvalidOperationException>(() => attackingW.Attack(defendingW));
        }

        [TestCase(30)]
        [TestCase(15)]
        [TestCase(0)]

        public void WarriorAttackMethod_ShouldThrowException_IfDefendingWarriorHp_IsLessOrEqualTo_MIN_ATTACK_HP(int hp)
        {
            Warrior attackingW = new Warrior("Pesho", 30, 50);
            Warrior defendingW = new Warrior("Gosho", 10, hp);

            Assert.Throws<InvalidOperationException>(() => attackingW.Attack(defendingW));
        }

        [TestCase(51)]
        [TestCase(150)]

        public void WarriorAttackMethod_ShouldThrowException_IfAttackingWarriorHp_IsLessThanDefendingWariorDamage(int deffenderDamage)
        {
            Warrior attackingW = new Warrior("Pesho", 30, 50);
            Warrior defendingW = new Warrior("Gosho",deffenderDamage , 100);

            Assert.Throws<InvalidOperationException>(() => attackingW.Attack(defendingW));
        }
    }
}