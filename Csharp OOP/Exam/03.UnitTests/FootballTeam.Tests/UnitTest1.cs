using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballTeam team;

        [SetUp]
        public void Setup()
        {
            string name = "Euro";
            int capacity = 15;
            this.team = new FootballTeam(name, capacity);
        }

        [Test]
        public void Test_ConstructorShouldSetName()
        {
            string expectedName = "Euro";
            string actualName = this.team.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Test_ConstructorShouldSetCapacit()
        {
            int expectedCapacity = 15;
            int actualCapacity = this.team.Capacity;

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }


        [Test]
        public void Test_ConstructorShouldInitializePlayters()
        {
            int expectedCount = 0;
            int actualCount = this.team.Players.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_NamePropertyShouldThrowExceprionIfValueIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam(name, 15));
        }

        [TestCase(14)]
        [TestCase(0)]
        [TestCase(-1)]
        public void Test_CapacityPropertyShouldThrowExceprionIfValueIsLessThan15(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam("Euro", capacity));
        }

        [Test]
        public void Test_PlayersPropertyShouldReturnPlayersCount()
        {
            FootballPlayer player1 = new FootballPlayer("Gosho", 1, "Forward");
            FootballPlayer player2 = new FootballPlayer("Pesho", 2, "Midfielder");
            FootballPlayer player3 = new FootballPlayer("Misho", 3, "Goalkeeper");

            this.team.AddNewPlayer(player1);
            this.team.AddNewPlayer(player2);
            this.team.AddNewPlayer(player3);

            int expectedCount = 3;
            int actualCount = this.team.Players.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_AddNewPlayerPropertyShouldReturnStringIfNoPosition()
        {
            FootballPlayer player1 = new FootballPlayer("Gosho", 1, "Forward");
            FootballPlayer player2 = new FootballPlayer("Pesho", 2, "Midfielder");

            for (int i = 0; i < 15; i++)
            {
                this.team.AddNewPlayer(player1);
            }

            string expectedString = "No more positions available!";
            string actualString = this.team.AddNewPlayer(player2);

            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void Test_AddNewPlayerPropertyShouldReturnStringWithPlayerInfo()
        {
            FootballPlayer player1 = new FootballPlayer("Gosho", 1, "Forward");
            this.team.AddNewPlayer(player1);

            string expectedString = "Added player Gosho in position Forward with number 1";
            string actualString = this.team.AddNewPlayer(player1);

            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void Test_PickPlayerPropertyShouldReturnPlayer()
        {
            FootballPlayer player1 = new FootballPlayer("Gosho", 1, "Forward");
            FootballPlayer expectedPlayer = new FootballPlayer("Pesho", 2, "Midfielder");
            FootballPlayer player3 = new FootballPlayer("Misho", 3, "Goalkeeper");

            this.team.AddNewPlayer(player1);
            this.team.AddNewPlayer(expectedPlayer);
            this.team.AddNewPlayer(player3);

            FootballPlayer actualPlayer = this.team.PickPlayer("Pesho");

            Assert.AreEqual(expectedPlayer, actualPlayer);
        }

        [Test]
        public void Test_PickPlayerPropertyShouldReturnNullIfPlayerNotExsists()
        {
            FootballPlayer player1 = new FootballPlayer("Gosho", 1, "Forward");
            FootballPlayer player3 = new FootballPlayer("Misho", 3, "Goalkeeper");

            this.team.AddNewPlayer(player1);
            this.team.AddNewPlayer(player3);

            FootballPlayer actualPlayer = this.team.PickPlayer("Oncho");

            Assert.AreEqual(null, actualPlayer);
        }

        [Test]
        public void Test_PlayerScorePropertyShouldReturnString()
        {
            FootballPlayer player1 = new FootballPlayer("Gosho", 1, "Forward");
            FootballPlayer player3 = new FootballPlayer("Misho", 3, "Goalkeeper");

            this.team.AddNewPlayer(player1);
            this.team.AddNewPlayer(player3);

            player1.Score();
            //player1.Score();

            string expectedString = "Gosho scored and now has 2 for this season!";
            string actualString = this.team.PlayerScore(1);

            Assert.AreEqual(expectedString, actualString);
        }


        [Test]
        public void Test_PlayerScorePropertyShouldReturnNullIfPlayerNotExsists()
        {
            FootballPlayer player1 = new FootballPlayer("Gosho", 1, "Forward");
            FootballPlayer player3 = new FootballPlayer("Misho", 3, "Goalkeeper");

            this.team.AddNewPlayer(player1);
            this.team.AddNewPlayer(player3);

            Assert.Throws<NullReferenceException>(() => this.team.PlayerScore(2));
        }
    }
}