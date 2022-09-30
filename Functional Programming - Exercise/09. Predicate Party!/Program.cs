using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> peopleList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = String.Empty;

            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] commandArg = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = commandArg[0];
                string parameter = commandArg[1];
                string filter = commandArg[2];

                if (action == "Remove")
                {
                    peopleList.RemoveAll(GetPredicate(parameter, filter));
                }
                else if (action == "Double")
                {
                    List<string> personToDouble = peopleList.FindAll(GetPredicate(parameter, filter));
                    int index = peopleList.FindIndex(GetPredicate(parameter, filter));

                    if (index >= 0)
                    {
                        peopleList.InsertRange(index, personToDouble);
                    }
                    
                }
            }

            if (peopleList.Count > 0)
            {
                Console.WriteLine($"{String.Join(", ", peopleList)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Predicate<string> GetPredicate(string parameter, string filter)
        {
            if (parameter == "StartsWith")
            {
                return s => s.StartsWith(filter);
            }
            else if (parameter == "EndsWith")
            {
                return s => s.EndsWith(filter);
            }
            else if (parameter == "Length")
            {
                return s => s.Length == int.Parse(filter);
            }
            else
            {
                return default;
            }
        }
    }
}
