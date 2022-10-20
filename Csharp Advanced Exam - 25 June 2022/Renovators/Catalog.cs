using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            renovators = new List<Renovator>();
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count => renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            else
            {
                if (renovators.Count < NeededRenovators)
                {
                    renovators.Add(renovator);
                    return $"Successfully added {renovator.Name} to the catalog.";
                }
                else
                {
                    return "Renovators are no more needed.";
                }
            }
        }

        public bool RemoveRenovator(string name) => renovators.Remove(renovators.FirstOrDefault(r => r.Name == name));

        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = renovators.Where(r => r.Type == type).Count();
            renovators.RemoveAll(r => r.Type == type);

            return count;
        }

        public Renovator HireRenovator(string name)
        {
            Renovator renovatorToHire = renovators.FirstOrDefault(r => r.Name == name);

            if (renovatorToHire != null)
            {
                renovatorToHire.Hired = true;
            }

            return renovatorToHire;
        }

        public List<Renovator> PayRenovators(int days) => renovators.Where(r => r.Days >= days).ToList();

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Renovators available for Project {Project}:");

            foreach (var renovator in renovators.Where(r => r.Hired == false))
            {
                output.AppendLine(renovator.ToString());
            }

            return output.ToString().TrimEnd();
        }


    }
}
