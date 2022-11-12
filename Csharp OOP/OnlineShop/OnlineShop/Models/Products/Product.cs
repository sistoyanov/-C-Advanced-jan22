
namespace OnlineShop.Models.Products
{
    using System;
    using Common.Constants;
    public abstract class Product : IProduct
    {
        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;

        public Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.OverallPerformance = overallPerformance;
        }

        public int Id
        {
            get { return id; }
            private set
            {
                if (value <= 0)
                {
                    throw new AggregateException(string.Format(ExceptionMessages.InvalidProductId));
                }

                this.id = value;
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new AggregateException(string.Format(ExceptionMessages.InvalidManufacturer));
                }

                this.manufacturer = value;
            }

        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new AggregateException(string.Format(ExceptionMessages.InvalidModel));
                }

                this.model = value;
            }
        }

        public virtual decimal Price
        {
            get { return price; }
            private set
            {
                if (value <= 0)
                {
                    throw new AggregateException(string.Format(ExceptionMessages.InvalidPrice));
                }

                this.price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get { return overallPerformance; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidOverallPerformance));
                }

                this.overallPerformance = value; 
            }
        }

        public override string ToString()
        {
            return $"Overall Performance: {this.OverallPerformance}. Price: {this.Price} - {nameof(Product)}: {this.Manufacturer} {this.Model} (Id: {this.Id})";
        }
    }
}
