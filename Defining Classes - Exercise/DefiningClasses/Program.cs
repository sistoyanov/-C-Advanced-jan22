using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            Family family = new Family();
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < counter; i++)
            {
                string[] personDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = personDetails[0];
                int personAge = int.Parse(personDetails[1]);

                Person personToAdd = new Person(personName, personAge);
                family.AddMember(personToAdd);
            }

            List<Person> olderThan30 = family.GetOldestMember().OrderBy(x => x.Name).ToList();
            foreach (var person in olderThan30)
            {
                output.AppendLine($"{person.Name} - {person.Age}");
            }

            Console.WriteLine(output.ToString());
        }
    }
}
