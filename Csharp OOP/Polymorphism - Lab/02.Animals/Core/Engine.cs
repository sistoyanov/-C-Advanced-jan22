namespace Animals.Core
{
    using System;
    using IO.Interfaces;
    using Interfaces;
    using Models;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            Animal cat = new Cat("Peter", "Whiskas");
            Animal dog = new Dog("George", "Meat");

            this.writer.WriteLine(cat.ExplainSelf());
            this.writer.WriteLine(dog.ExplainSelf());

        }
    }
}
