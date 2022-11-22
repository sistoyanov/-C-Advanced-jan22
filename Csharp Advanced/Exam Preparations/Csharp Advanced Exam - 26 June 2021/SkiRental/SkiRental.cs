using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {

        private List<Ski> skis;
        public SkiRental(string name, int capacity)
        {
            skis = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return skis.Count; } }

        public void Add(Ski ski)
        {
            if (Count < Capacity)
            {
                skis.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            return skis.Remove(skis.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model));
        }

        public Ski GetNewestSki()
        {
            return skis.OrderByDescending(s => s.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return skis.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder ouput = new StringBuilder();
            ouput.AppendLine($"The skis stored in {Name}:");
            foreach (Ski ski in skis)
            {
                ouput.AppendLine(ski.ToString());
            }
            return ouput.ToString().TrimEnd();
        }
    }
}
