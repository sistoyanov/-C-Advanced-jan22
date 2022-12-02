using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private HeroRepository heroRepository;

    [SetUp]
    public void StartUp()
    {
        this.heroRepository = new HeroRepository();
    }

    [Test]
    public void Test_ConstructorShouldInitializeData()
    {
        int expectedCount = 0;
        int actulaCount = this.heroRepository.Heroes.Count;

        Assert.AreEqual(expectedCount, actulaCount);
    }

    [Test]
    public void Test_CreateMethodSholdThrowException_IfHeroIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => this.heroRepository.Create(null));
    }

    [Test]
    public void Test_CreateMethodSholdThrowException_IfHeroExists()
    {
        Hero hero1 = new Hero("Test1", 1);
        Hero hero2 = new Hero("Test2", 2);

        this.heroRepository.Create(hero1);
        this.heroRepository.Create(hero2);

        Assert.Throws<InvalidOperationException>(() => this.heroRepository.Create(hero1));
    }

    [Test]
    public void Test_CreateMethodSholdAddHero()
    {
        Hero expectedHero = new Hero("Test1", 1);
        Hero hero2 = new Hero("Test2", 2);
        this.heroRepository.Create(expectedHero);
        this.heroRepository.Create(hero2);

        Hero actulaHero = this.heroRepository.Heroes.FirstOrDefault(h => h.Name == "Test1");

        Assert.AreEqual(expectedHero, actulaHero);
    }

    [Test]
    public void Test_CreateMethodSholdReturnString()
    {
        Hero hero = new Hero("Test2", 2);

        string expectedString = $"Successfully added hero Test2 with level 2";
        string actualString = this.heroRepository.Create(hero);

        Assert.AreEqual(expectedString, actualString);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("    ")]

    public void Test_RemoveMethodSholdThrowException_IfStringIsNullOrWhiteSpace(string name)
    {
        Assert.Throws<ArgumentNullException>(() => this.heroRepository.Remove(name));
    }

    [Test]
    public void Test_RemoveMethodSholdReturnTrue_IfHeroRemoved()
    {
        Hero hero1 = new Hero("Test1", 1);
        Hero hero2 = new Hero("Test2", 2);
        Hero hero3 = new Hero("Test3", 3);

        this.heroRepository.Create(hero1);
        this.heroRepository.Create(hero2);
        this.heroRepository.Create(hero3);

        bool IsRemoved = this.heroRepository.Remove("Test2");

        Assert.IsTrue(IsRemoved);
    }

    [Test]
    public void Test_RemoveMethodSholdReturnFalse_IfHeroNotRemoved()
    {
        Hero hero1 = new Hero("Test1", 1);
        Hero hero2 = new Hero("Test2", 2);

        this.heroRepository.Create(hero1);
        this.heroRepository.Create(hero2);

        bool IsRemoved = this.heroRepository.Remove("Test3");

        Assert.IsFalse(IsRemoved);
    }

    [Test]
    public void Test_RemoveMethodSholdRemoveHero()
    {
        Hero hero1 = new Hero("Test1", 1);
        Hero hero2 = new Hero("Test2", 2);
        Hero hero3 = new Hero("Test3", 3);

        this.heroRepository.Create(hero1);
        this.heroRepository.Create(hero2);
        this.heroRepository.Create(hero3);

        int expectedCount = 2;
        this.heroRepository.Remove("Test2");
        int actulaCount = this.heroRepository.Heroes.Count;

        Assert.AreEqual(expectedCount, actulaCount);
    }

    [Test]
    public void Test_RemoveMethodSholdRemoveHeroCorrectlly()
    {
        Hero hero1 = new Hero("Test1", 1);
        Hero hero2 = new Hero("Test2", 2);
        Hero hero3 = new Hero("Test3", 3);

        List<Hero> collection = new List<Hero> { hero1, hero3 };
        IReadOnlyCollection<Hero> expectedCollection = collection;

        this.heroRepository.Create(hero1);
        this.heroRepository.Create(hero2);
        this.heroRepository.Create(hero3);

        this.heroRepository.Remove("Test2");
        IReadOnlyCollection<Hero> actualCollection = this.heroRepository.Heroes;

        CollectionAssert.AreEqual(expectedCollection, actualCollection);
    }

    [Test]
    public void Test_GetHeroWithHighestLeveMethodSholdReturnHero()
    {
        Hero hero1 = new Hero("Test1", 10);
        Hero expectedHero = new Hero("Test2", 220);
        Hero hero3 = new Hero("Test3", 32);

        this.heroRepository.Create(hero1);
        this.heroRepository.Create(expectedHero);
        this.heroRepository.Create(hero3);

        Hero actualHero = this.heroRepository.GetHeroWithHighestLevel();

        Assert.AreEqual(expectedHero, actualHero);
    }

    [Test]
    public void Test_GetHeroWithHighestLeveMethodSholdReturnNull_IfNoHeroes()
    {
        Assert.Throws<IndexOutOfRangeException>(() => this.heroRepository.GetHeroWithHighestLevel());
    }

    [Test]
    public void Test_GetHeroMethodSholdReturnHero()
    {
        Hero hero1 = new Hero("Test1", 10);
        Hero expectedHero = new Hero("Misho", 220);
        Hero hero3 = new Hero("Test3", 32);

        this.heroRepository.Create(hero1);
        this.heroRepository.Create(expectedHero);
        this.heroRepository.Create(hero3);

        Hero actualHero = this.heroRepository.GetHero("Misho");

        Assert.AreEqual(expectedHero, actualHero);
    }

    [Test]
    public void Test_GetHeroMethodSholdReturnNull_IfNoHeroes()
    {
        Hero actualHero = this.heroRepository.GetHero("Misho");
        Assert.IsNull(actualHero);
    }

    [Test]
    public void Test_HeroPropertyShouldReturnIReadOnlyCollection()
    {
        Hero hero1 = new Hero("Test1", 1);
        Hero hero2 = new Hero("Test2", 2);
        Hero hero3 = new Hero("Test3", 3);

        List<Hero> collection = new List<Hero> { hero1, hero2, hero3 };
        IReadOnlyCollection<Hero> expectedCollection = collection;

        this.heroRepository.Create(hero1);
        this.heroRepository.Create(hero2);
        this.heroRepository.Create(hero3);

        IReadOnlyCollection<Hero> actualCollection = this.heroRepository.Heroes;

        CollectionAssert.AreEqual(expectedCollection, actualCollection);
    }
}


