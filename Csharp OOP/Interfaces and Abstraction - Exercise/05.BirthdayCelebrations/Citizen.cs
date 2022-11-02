using BirthdayCelebrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebration
{
    public class Citizen : IControlable, IBirthdate

    {
        public Citizen(string name, int age, string id, string burthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BurthDate = burthDate;
        }
        
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; set; }
        public string BurthDate { get ; set ; }
    }
}
