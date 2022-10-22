using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }

        public int Count => Multiprocessor.Count;

        public void Add (CPU cpu)
        {
            if (Count < Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand) => Multiprocessor.Remove(Multiprocessor.FirstOrDefault(p => p.Brand == brand));

        public CPU MostPowerful() => Multiprocessor.OrderByDescending(p => p.Frequency).FirstOrDefault();

        public CPU GetCPU(string brand) => Multiprocessor.FirstOrDefault(p => p.Brand == brand);

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"CPUs in the Computer {Model}:");
            foreach (var processor in Multiprocessor)
            {
                output.AppendLine(processor.ToString());
            }

            return output.ToString().TrimEnd();
        }

    }
}
