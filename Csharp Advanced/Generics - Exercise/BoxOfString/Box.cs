using System;
using System.Collections.Generic;
using System.Text;

namespace Generic_Box_of_String
{
    public class Box<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }
        public override string ToString()
        {
            return $"{this.Value.GetType()}: {this.Value}";
        }
    }

}
