using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : IControlable
    {
        public Robot(string model)
        {
            Model = model;
        }

        public string Model { get; private set; }
        public string Id { get ; set ; }
    }
}
