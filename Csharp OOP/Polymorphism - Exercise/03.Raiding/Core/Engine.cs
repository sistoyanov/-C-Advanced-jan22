namespace Raiding.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;
    using IO.Interfaces;
    using Raiding.Factories;
    using Raiding.Models;
    using Raiding.Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private Factory factory;
        ICollection<IHero> heroes;

        public Engine()
        {
            this.factory = new Factory();
            this.heroes = new List<IHero>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {

            int number = int.Parse(this.reader.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string heroName = this.reader.ReadLine();
                string heroType = this.reader.ReadLine();

                try
                {

                    heroes.Add(factory.CreateHero(heroName, heroType));
                }
                catch (AggregateException ae)
                {
                    i--;
                    this.writer.WriteLine(ae.Message);
                }

            }

            int bossPower = int.Parse(this.reader.ReadLine());
            this.writer.WriteLine(PrintResult(bossPower));
        }

        private string PrintResult(int bossPower)
        {
            StringBuilder output = new StringBuilder();
            int totalHeroesPower = heroes.Select(h => h.Power).ToArray().Sum();

            foreach (BaseHero hero in heroes)
            {
                output.AppendLine(hero.CastAbility());
            }
            
            output.AppendLine(totalHeroesPower >= bossPower ? "Victory!" : "Defeat...");

            return output.ToString().TrimEnd();
        }
    }
}
