// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
	using FestivalManager.Entities;
	using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

	[TestFixture]
	public class StageTests
	{
		Stage stage;

		[SetUp]
		
		public void SetUp()
		{
            stage = new Stage();
        }

		[Test]
	    public void Test_Constructor_InitializeData()
	    {
			
			Assert.IsNotNull(this.stage.Performers);	
		}

        [Test]
        public void Test_PerformerProperty_SholdReturCollectionCorrectlly()
        {
            Performer performer1 = new Performer("Pesho", "Ivanov", 30);
            Performer performer2 = new Performer("Gosho", "Penov", 20);
            Performer performer3 = new Performer("Tosho", "Petrov", 72);

            this.stage.AddPerformer(performer1);
            this.stage.AddPerformer(performer2);
            this.stage.AddPerformer(performer3);

            IReadOnlyCollection<Performer> expectedPerformers = new List<Performer> { performer1, performer2, performer3};
            IReadOnlyCollection<Performer> actulaPerformers = this.stage.Performers;

            CollectionAssert.AreEqual(actulaPerformers, expectedPerformers);
        }

        [Test]
        public void Test_AddPerformerMethod_ShouldAddPerformerCorrectly()
		{
			Performer expectedPerformer = new Performer("Pesho", "Ivanov", 30);
			this.stage.AddPerformer(expectedPerformer);
			Performer actualPerformer = stage.Performers.FirstOrDefault(p => p.FullName == "Pesho Ivanov");

			Assert.AreEqual(expectedPerformer, actualPerformer);
		}

        [TestCase (5)]
        [TestCase (0)]
        [TestCase (-1)]

        public void Test_AddPerformerMethod_ShouldThrowException_IfPErformerAgeIsLessThan18(int age)
		{
            Performer newPerformer = new Performer("Pesho", "Ivanov", age);
			Assert.Throws<ArgumentException>(() => this.stage.AddPerformer(newPerformer));
        }

        [Test]

        public void Test_AddPerformerMethod_ShouldThrowException_IfPErformerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.stage.AddPerformer(null));
        }

        [Test]

        public void Test_AddSongMethod_ShouldThrowException_IfSongIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.stage.AddSong(null));
        }

        [Test]

        public void Test_AddSongMethod_ShouldThrowException_IfSongDurationIsLessThanOneMinute()
        {
            Song newSong = new Song("Test", new TimeSpan(0, 0, 30));
            Assert.Throws<ArgumentException>(() => this.stage.AddSong(newSong));
        }

        [Test]

        public void Test_AddSongMethod_ShouldAddSongCorrectlly()
        {
            Song expecyedSong = new Song("Test", new TimeSpan(0, 2, 30));
            Performer performer = new Performer("Pesho", "Ivanov", 30);
            this.stage.AddSong(expecyedSong);
            this.stage.AddPerformer(performer);
            this.stage.AddSongToPerformer("Test", "Pesho Ivanov");

            Song actualSong = this.stage.Performers.FirstOrDefault(p => p.FullName == "Pesho Ivanov").SongList.FirstOrDefault(s => s.Name == "Test");

            Assert.AreEqual(expecyedSong, actualSong);
        }

        [Test]

        public void Test_AddSongToPerformer_ShouldThrowException_IfSongIsNull()
		{
            Performer performer = new Performer("Pesho", "Ivanov", 30);
			this.stage.AddPerformer(performer);

			Assert.Throws<ArgumentNullException>(() => this.stage.AddSongToPerformer(null, "Pesho Ivanov"));
        }

        [Test]

        public void Test_AddSongToPerformer_ShouldThrowException_IfPerformerIsNull()
        {
            Song newSong = new Song("Test", new TimeSpan(0, 2, 30));
            this.stage.AddSong(newSong);

            Assert.Throws<ArgumentNullException>(() => this.stage.AddSongToPerformer("Test", null));
        }

        [Test]

        public void Test_AddSongToPerformer_ShouldAddSongCorrectlly()
        {
			string songName = "Test";
			string performerName = "Pesho Ivanov";

            Song expectedSong = new Song(songName, new TimeSpan(0, 2, 30));
            Performer performer = new Performer("Pesho", "Ivanov", 30);
			this.stage.AddSong(expectedSong);
			this.stage.AddPerformer(performer);
			this.stage.AddSongToPerformer(songName, performerName);

			Song actualSong = this.stage.Performers.FirstOrDefault(p => p.FullName == performerName).SongList.FirstOrDefault(s => s.Name == songName);

			Assert.AreEqual(expectedSong, actualSong);
        }

        [Test]

        public void Test_AddSongToPerformer_ShouldReturnStringCorrectlly()
		{
            string songName = "Test";
            string performerName = "Pesho Ivanov";

            Song song = new Song(songName, new TimeSpan(0, 2, 30));
            Performer performer = new Performer("Pesho", "Ivanov", 30);
            this.stage.AddSong(song);
            this.stage.AddPerformer(performer);

            string expectedMessage = $"{song} will be performed by {performerName}";
            string actualMessage = this.stage.AddSongToPerformer(songName, performerName);

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]

        public void Test_PlayMethod_ShouldReturnStringCorrectly()
        {
            string song1Name = "Test1";
            string song2Name = "Test2";
            string song3Name = "Test3";

            string performer1Name = "Pesho Ivanov";
            string performer2Name = "Gosho Penov";
            string performer3Name = "Tosho Petrov";

            Performer performer1 = new Performer("Pesho", "Ivanov", 30);
            Performer performer2 = new Performer("Gosho", "Penov", 20);
            Performer performer3 = new Performer("Tosho", "Petrov", 72);

            Song song1 = new Song(song1Name, new TimeSpan(0, 2, 00));
            Song song2 = new Song(song2Name, new TimeSpan(0, 2, 30));
            Song song3 = new Song(song3Name, new TimeSpan(1, 2, 01));

            this.stage.AddPerformer(performer1);
            this.stage.AddPerformer(performer2);
            this.stage.AddPerformer(performer3);

            this.stage.AddSong(song1);
            this.stage.AddSong(song2);
            this.stage.AddSong(song3);

            this.stage.AddSongToPerformer(song1Name, performer1Name);
            this.stage.AddSongToPerformer(song2Name, performer1Name);
            this.stage.AddSongToPerformer(song3Name, performer1Name);

            this.stage.AddSongToPerformer(song1Name, performer2Name);

            this.stage.AddSongToPerformer(song2Name, performer3Name);
            this.stage.AddSongToPerformer(song3Name, performer3Name);

            int expectedSongCount = 6;
            int expectedPerformerCount = 3;
            string expectedString = $"{expectedPerformerCount} performers played {expectedSongCount} songs";
            string actualString = this.stage.Play();

            Assert.AreEqual(expectedString, actualString);
        }
    }
}