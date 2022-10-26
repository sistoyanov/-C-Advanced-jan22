using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> items;
        private int index;

        public ListyIterator(List<T> list)
        {
            this.items = new List<T>(list);
        }

        public bool Move()
        {
            if (index < items.Count - 1)
            {
                index++;
                return true;
            }

            return false;
        }

        public bool	HasNext()
        {
            if (index < items.Count - 1)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (items.Count > 0)
            {
                Console.WriteLine(items[index]);
            }
            else
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }

        public void PrintAll()
        {
            if (items.Count > 0)
            {
                Console.WriteLine(String.Join(" ", items));
            }
            else
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
     
    }
}
