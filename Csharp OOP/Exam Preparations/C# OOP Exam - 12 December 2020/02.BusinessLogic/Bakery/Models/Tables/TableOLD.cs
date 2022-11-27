
namespace Bakery.Models.Tables
{
    using BakedFoods.Contracts;
    using Bakery.Utilities.Messages;
    using Drinks.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using Tables.Contracts;
    public abstract class Table : ITable
    {
        private ICollection<IBakedFood> foodOrders;
        private ICollection<IDrink> drinkOrders;
        //private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        //private decimal pricePerPerson;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new HashSet<IBakedFood>();
            this.drinkOrders = new HashSet<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.IsReserved = false;
        }

        public int TableNumber  { get; private set; }  // only getter?

        public int Capacity
        {
            get { return this.capacity; }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidTableCapacity));
                }

                this.capacity = value; 
            }
        }

        public int NumberOfPeople    /// set might be private   
        {
            get { return this.numberOfPeople; }
            private set                                          
            {
                if (value <= 0)   /// only less than 0
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value; 
            }                                                   
        }

        public decimal PricePerPerson { get; private set; } // only get

        public bool IsReserved { get; private set; }  /// set might be private   

        public decimal Price => this.PricePerPerson * this.NumberOfPeople;  // only getter

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0; 
        }

        public decimal GetBill() 
        {
            decimal totalFoodsPrice = this.foodOrders.Sum(f => f.Price);
            decimal totalDrinksPRice = this.drinkOrders.Sum(d => d.Price);

            return this.Price + totalFoodsPrice + totalDrinksPRice;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Table: {this.TableNumber}")
                  .AppendLine($"Type: {this.GetType().Name}")        
                  .AppendLine($"Capacity: {this.Capacity}")
                  .AppendLine($"Price per Person: {this.PricePerPerson}");

            return output.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
           this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }
    }
}
