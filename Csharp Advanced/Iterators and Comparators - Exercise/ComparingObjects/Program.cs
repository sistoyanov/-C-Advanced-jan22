using System;
using System.Collections.Generic;
using System.Drawing;

namespace ComparingObjects
{
    public class StarUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] personDetails = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = personDetails[0];
                int age = int.Parse(personDetails[1]);
                string town = personDetails[2];

                Person person = new Person(name, age, town);
                persons.Add(person);
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            Person personToCompare = persons[index];
            int equal = 0;
            int different = 0;

            foreach (var person in persons)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    equal++;
                }
                else
                {
                    different++;
                }
            }

            if (equal == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {different} {persons.Count}");
            }
        }
    }
}
