using System.ComponentModel;

namespace Shapes.Models
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateArea() => this.height * this.width;

        public override double CalculatePerimeter() => 2 * (this.height + this.width);

        public override string Draw() => base.Draw() + this.GetType().Name;

    }
}
