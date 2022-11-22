using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> racers;
        public Race(string name, int capacity)
        {
            this.racers = new List<Racer>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return racers.Count; } }

        public void Add(Racer racer)
        {
            if (Count < Capacity)
            {
                racers.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racerToRemove = racers.FirstOrDefault(r => r.Name == name);

            if (racerToRemove != null)
            {
                racers.Remove(racerToRemove);
                return true;
            }

            return false;
        }

        public Racer GetOldestRacer()
        {
            return racers.OrderByDescending(r => r.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            return racers.FirstOrDefault(r => r.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return racers.OrderByDescending(r => r.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Racers participating at {Name}:");

            foreach (var racer in racers)
            {
                output.AppendLine(racer.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
