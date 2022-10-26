using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Person
{
    public class Person
    {
        //private int age;
        //private string name;
        public Person(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }

        public string Name { get; set; }
        public virtual int Age { get; set; }

        //{
        //    get { return age; }
        //    set
        //    {
        //        if (value > -1)
        //        {
        //            this.age = value;
        //        }
        //    }
        //}

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
