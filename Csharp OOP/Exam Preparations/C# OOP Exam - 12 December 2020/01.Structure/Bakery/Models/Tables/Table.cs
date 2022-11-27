
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
        }

        public int TableNumber  { get; private set; }

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
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value; 
            }                                                   
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }  /// set might be private   

        public decimal Price => this.PricePerPerson * this.NumberOfPeople;  // only getter

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;  /// validate is this work
        }

        public decimal GetBill()  // check if this works properlly 
        {
            decimal totalFoodsPrice = this.foodOrders.Select(f => f.Price).Sum();
            decimal totalDrinksPRice = this.foodOrders.Select(f => f.Price).Sum();

            return totalFoodsPrice + totalDrinksPRice;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Table: {this.TableNumber}")
                  .AppendLine($"Type: {typeof(Table)}")        ///Validate if this works
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
