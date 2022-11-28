
namespace WarCroft.Entities.Inventory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WarCroft.Constants;
    using WarCroft.Entities.Items;
    public abstract class Bag : IBag
    {
        private int capacity = 100;
        private ICollection<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get => this.capacity; set => this.capacity = value; }

        public int Load => this.items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => this.Items as IReadOnlyCollection<Item>;

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ExceedMaximumBagCapacity));
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count <= 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.EmptyBag));
            }

            Item itemToRemove = this.items.FirstOrDefault(i => i.GetType().Name == name);

            if (itemToRemove is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.items.Remove(itemToRemove);
            return itemToRemove;
        }
    }
}
