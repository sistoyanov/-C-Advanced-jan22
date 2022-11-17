
namespace CommandPattern.Core.Models
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandDetails = args.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            string commandType = commandDetails[0];
            string[] commandArgs = commandDetails.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandType + "Command");
            ICommand currentComand = (ICommand)Activator.CreateInstance(type);

            string result = currentComand.Execute(commandArgs);

            return result;
        }
    }
}
