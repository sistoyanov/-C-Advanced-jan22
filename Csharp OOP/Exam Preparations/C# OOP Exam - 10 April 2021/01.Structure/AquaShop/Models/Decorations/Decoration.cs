using AquaShop.Models.Decorations.Contracts;

namespace AquaShop.Models.Decorations
{
    public abstract class Decoration : IDecoration
    {
        private int comfort;
        private decimal price;

        protected Decoration(int comfort, decimal price)
        {
            this.Comfort = comfort;
            this.Price = price;
        }

        public int Comfort
        {
            get { return comfort; }
            private set { comfort = value; }
        }

        public decimal Price
        {
            get { return price; }
            private set { price = value; }
        }

    }
}
