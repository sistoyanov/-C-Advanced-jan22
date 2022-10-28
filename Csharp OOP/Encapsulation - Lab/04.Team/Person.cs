using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        private const int MIN_NAME_LENGTH = 2;
        private const int DEFAULT_AGE = 3;
        private const decimal DEFAULT_SALARY = 650;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName 
        { 
            get => this.firstName;
            private set
            {
                if (value.Length > MIN_NAME_LENGTH)
                {
                    this.firstName = value;
                }
                else
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                
            } 
        }

        public string LastName 
        { 
            get => this.lastName;
            private set
            {
                if (value.Length > MIN_NAME_LENGTH)
                {
                    this.lastName = value;
                }
                else
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
            }
        }

        public int Age 
        { 
            get => this.age; 
            private set
            {
                if (value > DEFAULT_AGE)
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                
            }
        }

        public decimal Salary 
        {
            get => this.salary;
            private set
            {
                if (value > DEFAULT_SALARY)
                {
                    this.salary = value;
                }
                else
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }

        public void IncreaseSalary(decimal percentage)
        {
            decimal bonus = 0;

            if (this.Age > 30)
            {
                bonus = (this.Salary * percentage) / 100;
                this.Salary += bonus;
            }
            else
            {
                bonus = (this.Salary * percentage) / 200;
                this.Salary += bonus;
            }
        }

    }
}
