using System;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
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
    }
}
