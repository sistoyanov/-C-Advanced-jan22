using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.drones = new List<Drone>();
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count => drones.Count;

        public string AddDrone(Drone drone)
        {

            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            else
            {
                if (drones.Count < Capacity)
                {
                    drones.Add(drone);
                    return $"Successfully added {drone.Name} to the airfield.";
                }
                else
                {
                    return "Airfield is full.";
                }
            }
        }

        public bool RemoveDrone(string name) => drones.Remove(drones.FirstOrDefault(d => d.Name == name));

        public int RemoveDroneByBrand(string brand)
        {
            int count = drones.Where(d => d.Brand == brand).Count();

            if (count > 0)
            {
                drones.RemoveAll(d => d.Brand == brand);
            }

            return count;
        }

        public Drone FlyDrone(string name)
        {
            Drone droneToFly = drones.FirstOrDefault(d => d.Name == name);
            
            if (droneToFly != null)
            {
                droneToFly.Available = false;
            }

            return droneToFly;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> dronesToFly = drones.Where(d => d.Range >= range).ToList();

            foreach (var drone in dronesToFly)
            {
                drone.Available = false;
            }

            return dronesToFly;
        }
        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Drones available at {Name}:");

            foreach (var drone in drones.Where(d => d.Available == true))
            {
                output.AppendLine(drone.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
