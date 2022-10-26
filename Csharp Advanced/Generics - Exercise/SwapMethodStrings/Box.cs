using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SwapMethodStrings
{
    public class Box<T>
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

        public void Swap(int currentIdx, int newIdx)
        {
            T oldValue = Value[currentIdx];
            Value [currentIdx] = Value[newIdx];
            Value[newIdx] = oldValue;
        }
    }
}
