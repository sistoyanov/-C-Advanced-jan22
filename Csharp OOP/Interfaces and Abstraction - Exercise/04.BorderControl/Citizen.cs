using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IControlable

    {
        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; set; }
    }
}
