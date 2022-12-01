namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        RobotManager robotManager;

        [SetUp]
        public void SetUp()
        {
            robotManager = new RobotManager(3);
        }

        [Test]
        public void Test_ConstructorSholdIntializeData()
        {
            int expectedCount = 0;
            int actualCount = this.robotManager.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_ConstructorSholdSetCapacity()
        {
            int expectedCapacity = 3;
            int actualCapacity = this.robotManager.Capacity;

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [TestCase(-1)]
        [TestCase(-67532)]
        [TestCase(int.MinValue)]
        public void Test_CapacityMethodSholdThrowExecption_IfValueIsNegative(int capacity)
        {

            Assert.Throws<ArgumentException>(() => new RobotManager(capacity));
        }

        [Test]
        public void Test_AddMethodSholdAddRobot()
        {
            Robot robot = new Robot("Robot", 100);
            this.robotManager.Add(robot);

            Assert.AreEqual(1, this.robotManager.Count);
        }

        [Test]
        public void Test_AddMethodSholThorowExeptionIfRobotExists()
        {
            Robot robot1 = new Robot("Robot1", 100);
            this.robotManager.Add(robot1);
            Robot robot2 = new Robot("Robot2", 10);
            this.robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() => this.robotManager.Add(robot1));
        }

        [Test]
        public void Test_AddMethodSholThorowExeptionIfNoCapacity()
        {
            Robot robot1 = new Robot("Robot1", 100);
            Robot robot2 = new Robot("Robot2", 10);
            Robot robot3 = new Robot("Robot3", 90);
            Robot robot4 = new Robot("Robot4", 74);

            this.robotManager.Add(robot1);
            this.robotManager.Add(robot2);
            this.robotManager.Add(robot3);

            Assert.Throws<InvalidOperationException>(() => this.robotManager.Add(robot4));
        }

        [Test]
        public void Test_RemoveMethodSholdARemoveRobot()
        {
            Robot robot1 = new Robot("Robot1", 100);
            Robot robot2 = new Robot("Robot2", 10);
            Robot robot3 = new Robot("Robot3", 90);

            this.robotManager.Add(robot1);
            this.robotManager.Add(robot2);
            this.robotManager.Add(robot3);

            this.robotManager.Remove("Robot2");

            Assert.AreEqual(2, this.robotManager.Count);
        }

        [Test]
        public void Test_RemoveMethodSholdThrowException_IfRobotNotExists()
        {
            Robot robot1 = new Robot("Robot1", 100);
            Robot robot2 = new Robot("Robot2", 10);

            this.robotManager.Add(robot1);
            this.robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() => this.robotManager.Remove("Robot4"));
        }

        [Test]
        public void Test_WorkMethodSholdThrowException_IfRobotNotExists()
        {
            Robot robot1 = new Robot("Robot1", 100);
            Robot robot2 = new Robot("Robot2", 10);

            this.robotManager.Add(robot1);
            this.robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() => this.robotManager.Work("Robot4", "Dig", 20));
        }

        [Test]
        public void Test_WorkMethodSholdThrowException_IfRobotBatteryIsLessThanBatteryUsage()
        {
            Robot robot1 = new Robot("Robot1", 100);
            this.robotManager.Add(robot1);

            Assert.Throws<InvalidOperationException>(() => this.robotManager.Work("Robot1", "Dig", 120));
        }

        [Test]
        public void Test_WorkMethodSholdDecreaseBattery()
        {
            Robot robot1 = new Robot("Robot1", 100);
            this.robotManager.Add(robot1);
            this.robotManager.Work("Robot1", "Dig", 20);

            Assert.AreEqual(80, robot1.Battery);
        }

        [Test]
        public void Test_ChargekMethodSholdThrowException_IfRobotNotExists()
        {
            Robot robot1 = new Robot("Robot1", 100);
            Robot robot2 = new Robot("Robot2", 10);

            this.robotManager.Add(robot1);
            this.robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() => this.robotManager.Charge("Robot4"));
        }

        [Test]
        public void Test_ChargekMethodSholdChargeBatteryToMax()
        {
            Robot robot1 = new Robot("Robot1", 100);
            this.robotManager.Add(robot1);
            this.robotManager.Work("Robot1", "Dig", 80);
            robotManager.Charge("Robot1");

            Assert.AreEqual(100, robot1.Battery);
        }
    }
}
