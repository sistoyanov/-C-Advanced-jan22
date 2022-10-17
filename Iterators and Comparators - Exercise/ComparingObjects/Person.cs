using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            int output = Name.CompareTo(other.Name);

            if (output != 0)
            {
                return output;
            }

            output = Age.CompareTo(other.Age);

            if (output != 0)
            {
                return output;
            }

            return Town.CompareTo(other.Town);
        }
    }
}
