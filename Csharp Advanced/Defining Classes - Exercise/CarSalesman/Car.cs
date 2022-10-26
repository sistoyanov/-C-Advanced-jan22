using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Color = "n/a";
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{this.Model}:");
            output.AppendLine($" {this.Engine.Model}:");
            output.AppendLine($"  Power: {this.Engine.Power}");

            if (this.Engine.Displacement > 0)
            {
                output.AppendLine($"  Displacement: {this.Engine.Displacement}");
            }
            else
            {
                output.AppendLine($"  Displacement: n/a");
            }
            
            output.AppendLine($"  Efficiency: {this.Engine.Efficiency}");

            if (this.Weight > 0)
            {
                output.AppendLine($" Weight: {this.Weight}");
            }
            else
            {
                output.AppendLine($" Weight: n/a");
            }
            
            output.AppendLine($" Color: {this.Color}");

            return output.ToString().TrimEnd();
        }
    }

    
}
