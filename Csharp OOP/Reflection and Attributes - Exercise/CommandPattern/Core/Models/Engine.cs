
namespace CommandPattern.Core.Models
{
    using Contracts;
    using System;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandIterpreter)
        {
            this.commandInterpreter = commandIterpreter;
        }

        public void Run()
        {
            string input = Console.ReadLine();

            string result = commandInterpreter.Read(input);

            Console.WriteLine(result);
        }
    }
}
