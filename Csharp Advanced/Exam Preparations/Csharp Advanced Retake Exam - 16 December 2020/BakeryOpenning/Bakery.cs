using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> employees;
        public Bakery(string name, int capacity)
        {
            this.employees = new List<Employee>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return employees.Count; } }

        public void Add(Employee employee)
        {
            if (Count < Capacity)
            {
                employees.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee employeeToRemove = employees.FirstOrDefault(x => x.Name == name);

            if (employeeToRemove != null)
            {
                employees.Remove(employeeToRemove);
                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee()
        {
            return employees.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            return employees.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            StringBuilder ouput = new StringBuilder();

            ouput.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var employee in employees)
            {
                ouput.AppendLine(employee.ToString());
            }

            return ouput.ToString().TrimEnd();
        }
    }
}
