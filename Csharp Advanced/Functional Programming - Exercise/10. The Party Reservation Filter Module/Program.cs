using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<string>, Dictionary<string, Predicate<string>>, List<string>> filterPeople = (peopleList, predicates) =>
            {
                foreach (var predicate in predicates)
                {
                     peopleList.RemoveAll(predicate.Value);
                }

                return peopleList;
            };

            List<string> peopleList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string,Predicate<string>> predicates = new Dictionary<string, Predicate<string>>();
            string command = String.Empty;

            while ((command = Console.ReadLine()) != "Print")
            {
                string[] commandArg = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string action = commandArg[0];
                string parameter = commandArg[1];
                string filter = commandArg[2];

                if (action == "Add filter")
                {
                    predicates.Add(parameter + filter ,GetPredicate(parameter, filter));
                }
                else if (action == "Remove filter")
                {
                    predicates.Remove(parameter + filter);
                    
                }
            }

            filterPeople(peopleList, predicates);
            Console.WriteLine(String.Join(" ", peopleList));

        }

        static Predicate<string> GetPredicate(string parameter, string filter)
        {
            if (parameter == "Starts with")
            {
                return s => s.StartsWith(filter);
            }
            else if (parameter == "Ends with")
            {
                return s => s.EndsWith(filter);
            }
            else if (parameter == "Contains")
            {
                return s => s.Contains(filter);
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
