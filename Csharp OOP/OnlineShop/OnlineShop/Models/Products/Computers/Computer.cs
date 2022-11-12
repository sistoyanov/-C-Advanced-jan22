namespace OnlineShop.Models.Products.Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Components;
    using Common.Constants;
    using Peripherals;

    public abstract class Computer : Product, IComputer
    {
        private HashSet<IComponent> components;
        private HashSet<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new HashSet<IComponent>();
            peripherals = new HashSet<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components { get; private set; }

        public IReadOnlyCollection<IPeripheral> Peripherals { get; private set; }

        public override double OverallPerformance
        {
            get 
            {
                if (components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    return this.Components.Sum(c => c.OverallPerformance) / this.Components.Count;
                }
                
            }
        }

        public override decimal Price
        {
            get 
            {
                return this.Price + this.Components.Sum(c => c.Price) + this.Peripherals.Sum(p => p.Price);
 
            }
        }

        public void AddComponent(IComponent component)
        {
            if (this.Components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, nameof(Computer), base.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, nameof(Computer), base.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (this.Components.Any(c => c.GetType().Name == componentType.GetType().Name) || this.Components.Count == 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType.GetType().Name, nameof(Computer), base.Id));
            }

            return this.Components.FirstOrDefault(c => c.GetType().Name == componentType.GetType().Name);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.Peripherals.Any(p => p.GetType().Name == peripheralType.GetType().Name) || this.Peripherals.Count == 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheralType.GetType().Name, nameof(Computer), base.Id));
            }

            return this.Peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType.GetType().Name);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(base.ToString())
                  .AppendLine($" Components ({this.Components.Count}):");

            foreach (IComponent component in this.Components)
            {
                output.AppendLine($"  {component}");
            }

            output.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({this.Peripherals.Sum(p => p.OverallPerformance) / this.Peripherals.Count}):");

            foreach (IPeripheral peripheral in this.Peripherals)
            {
                output.Append($"  {peripheral}");
            }

            return output.ToString().TrimEnd();
        }

        Components.IComponent IComputer.RemoveComponent(string componentType)
        {
            throw new NotImplementedException();
        }
    }
}
