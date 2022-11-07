namespace Raiding.Factories
{
    using System;
    using Models.Interfaces;
    using Interfaces;
    using Models;
    using Exceptions;

    public class Factory : IFactory
    {
        IHero hero;
        public IHero CreateHero(string heroName, string heroType)
        {
            if (heroType == "Druid")
            {
                hero = new Druid(heroName);
            }
            else if (heroType == "Paladin")
            {
                hero = new Paladin(heroName);
            }
            else if (heroType == "Rogue")
            {
                hero = new Rogue(heroName);
            }
            else if (heroType == "Warrior")
            {
                hero = new Warrior(heroName);
            }
            else
            {
                throw new AggregateException(string.Format(ExceptionMessages.InvalidType));
            }

            return hero;
        }

    }
}
