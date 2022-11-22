namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]

        public void ArenaConstructor_ShouldInisialize_WarriorCollection()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
        }

        [Test]

        public void ArenaCountProperty_ShouldReturn_WarriorCount()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Pesho", 50, 100);
            int expectedCount = 1;

            arena.Enroll(warrior);
            int actualCount = arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]

        public void ArenaEnrollMethod_ShouldAddWarrior()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Pesho", 50, 100);
            int expectedCount = 1;

            arena.Enroll(warrior);
            int actualCount = arena.Warriors.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]

        public void ArenaEnrollMethod_ShouldThrowException_IfWariorAlreadyEnroled()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Pesho", 50, 100);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]

        public void ArenaFightMethod_ShouldThrowException_IfAttakingWrriorName_NotExists()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Pesho", 50, 100);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("BMW", "Pesho"));

        }

        [Test]

        public void ArenaFightMethod_ShouldThrowException_IfDefendingWrriorName_NotExists()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Pesho", 50, 100);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Pesho", "BMW"));
        }

        [Test]
        public void Test_FightMethod_ShouldWork()
        {
            Arena arena = new Arena();

            arena.Enroll(new Warrior("Gosho", 50, 50));
            arena.Enroll(new Warrior("Pesho", 50, 55));

            arena.Fight("Gosho", "Pesho");

            int expectedAttackWarriorHp = 0;
            int expectedDefendWarriorHP = 5;

            Warrior attackWarrior = arena.Warriors.First(w => w.Name == "Gosho");
            Warrior defendWarrior = arena.Warriors.First(w => w.Name == "Pesho");

            Assert.AreEqual(expectedAttackWarriorHp, attackWarrior.HP);
            Assert.AreEqual(expectedDefendWarriorHP, defendWarrior.HP);
        }
    }
}
