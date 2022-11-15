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
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new HashSet<IComponent>();
            this.peripherals = new HashSet<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components as IReadOnlyCollection<IComponent>;

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals as IReadOnlyCollection<IPeripheral>;

        public override double OverallPerformance
        {
            get 
            {
                if (this.Components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    return base.OverallPerformance + (this.Components.Sum(c => c.OverallPerformance) / this.Components.Count);
                }
                
            }
        }

        public override decimal Price
        {
            get 
            {
                return base.Price + this.components.Sum(c => c.Price) + this.peripherals.Sum(p => p.Price);
 
            }
        }

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, nameof(Computer), base.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, nameof(Computer), base.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!this.components.Any(c => c.GetType().Name == componentType) || this.Components.Count == 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, base.GetType().Name, base.Id));
            }

            IComponent componentToRemove = components.First(c => c.GetType().Name == componentType);
            this.components.Remove(componentToRemove);
     
            return componentToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!this.peripherals.Any(p => p.GetType().Name == peripheralType) || this.Peripherals.Count == 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, base.GetType().Name, base.Id));
            }

            IPeripheral peripheralToRemove = peripherals.First(p => p.GetType().Name == peripheralType);
            this.peripherals.Remove(peripheralToRemove);

            return peripheralToRemove;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(base.ToString())
                  .AppendLine($" Components ({this.components.Count}):");

            foreach (IComponent component in this.components)
            {
                output.AppendLine($"  {component}");
            }

            output.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({(this.peripherals.Count > 0 ? (this.peripherals.Sum(p => p.OverallPerformance) / this.peripherals.Count) : 0):f2}):");

            foreach (IPeripheral peripheral in this.peripherals)
            {
                output.Append($"  {peripheral}");
            }

            return output.ToString().TrimEnd();
        }

    }
}
