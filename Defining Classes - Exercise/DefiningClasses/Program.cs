using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
            string[] personDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string personName = personDetails[0];
            int personAge = int.Parse(personDetails[1]);
            Person personToAdd = new Person(personName, personAge);
            personList.Add(personToAdd);
        }
    }
}
