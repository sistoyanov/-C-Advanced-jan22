using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class Animal
    {
		private string name;
        private int age;
        private string gender;
		public Animal(string name, int age, string gender)
		{
			this.Name = name;
			this.Age = age;
			this.Gender = gender;
		}

        public string Name
		{
			get { return name; }
			set 
			{
				if (!string.IsNullOrWhiteSpace(value))
				{
                    name = value;
                }
				else
				{

                    throw new InvalidOperationException("Invalid input!");
                }
			}
		}

		public int Age
		{
			get { return age; }
			set 
			{
				if (value > 0)
				{
                    age = value;
                }
				else
				{
                    throw new InvalidOperationException("Invalid input!");
                }
			}
		}

		public virtual string Gender
		{
			get { return gender; }
			set 
			{
				if (!string.IsNullOrWhiteSpace(value))
				{
                    gender = value;
                }
				else
				{
                    throw new InvalidOperationException("Invalid input!");
                
                }
				
			}
		}

        public virtual string ProduceSound()
        {
            return "";
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(this.GetType().Name.ToString());
            output.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            output.AppendLine(ProduceSound());
            return output.ToString().TrimEnd();
        }



    }
}
