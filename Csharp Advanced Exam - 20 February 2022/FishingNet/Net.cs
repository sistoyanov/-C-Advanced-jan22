using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish;

        public Net(string material, int capacity)
        {
            Fish = new List<Fish>();
            Material = material;
            Capacity = capacity;
        }

        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count => Fish.Count;

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            else
            {
                if (Fish.Count < Capacity)
                {
                    Fish.Add(fish);
                    return $"Successfully added {fish.FishType} to the fishing net.";
                }
                else
                {
                    return "Fishing net is full.";
                }
            }
        }

        public bool ReleaseFish(double weight) => Fish.Remove(Fish.FirstOrDefault(f => f.Weight == weight));

        public Fish GetFish(string fishType) => Fish.FirstOrDefault(f => f.FishType == fishType);

        public Fish GetBiggestFish() => Fish.OrderByDescending(f => f.Length).FirstOrDefault();

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Into the {Material}:");

            foreach (var fish in Fish.OrderByDescending(f => f.Length))
            {
                output.AppendLine(fish.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
