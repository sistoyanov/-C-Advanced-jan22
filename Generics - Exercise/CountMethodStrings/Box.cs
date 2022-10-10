using System;
using System.Collections.Generic;
using System.Text;

namespace CountMethodStrings
{
    public class Box<T> where T : IComparable<T>
    {
        public Box()
        {
            Value = new List<T>();
        }
        public List<T> Value { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            foreach (var item in Value)
            {
                output.AppendLine($"{typeof(T)}: {item}");
            }
            return output.ToString().TrimEnd();
        }

        public int Count (T itemToCompare)
        {
            int count = 0;

            foreach (var item in Value)
            {
                if (item.CompareTo(itemToCompare) > 0)
                {
                    count ++;
                }
            }

            return count;
        }
    }
}
