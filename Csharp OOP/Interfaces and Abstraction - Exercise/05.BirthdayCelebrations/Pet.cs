using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations 
{
    public class Pet : IBirthdate
    {
        public Pet(string name, string burthDate)
        {
            Name = name;
            BurthDate = burthDate;
        }

        public string Name { get; private set; }
        public string BurthDate { get ; set ; }
    }
}
