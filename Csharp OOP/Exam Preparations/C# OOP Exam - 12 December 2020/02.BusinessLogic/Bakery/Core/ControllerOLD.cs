using Bakery.Core.Contracts;

namespace Bakery.Core
{
    using Models.BakedFoods;
    using Models.BakedFoods.Contracts;
    using Models.Drinks;
    using Models.Drinks.Contracts;
    using Models.Tables;
    using Models.Tables.Contracts;
    using Utilities.Enums;
    using Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private ICollection<IBakedFood> foods;
        private ICollection<IDrink> drinks;
        private ICollection<ITable> tables;
        ITable table;
        IBakedFood food;
        IDrink drink;
        private decimal totalIncome;

        public Controller()
        {
            foods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {

            if (!Enum.TryParse(type, out DrinkType validDrink))
            {
                throw new InvalidOperationException("Invalid food type!");
            }

            if (validDrink == DrinkType.Water)
            {
                this.drink = new Water(name, portion, brand);
            }
            else if (validDrink == DrinkType.Tea)
            {
                this.drink = new Tea(name, portion, brand);
            }

            this.drinks.Add(drink);

            return string.Format(OutputMessages.DrinkAdded, name, brand);

        }

        public string AddFood(string type, string name, decimal price)
        {

            if (!Enum.TryParse(type, out BakedFoodType validFoodType))
            {

                throw new InvalidOperationException("Invalid food type!");
            }

            if (validFoodType == BakedFoodType.Bread)
            {
                this.food = new Bread(name, price);
            }
            else if (validFoodType == BakedFoodType.Cake)
            {
                this.food = new Cake(name, price);
            }

            this.foods.Add(this.food);

            return string.Format(OutputMessages.FoodAdded, name, type);

        }

        public string AddTable(string type, int tableNumber, int capacity)
        {

            if (!Enum.TryParse(type, out TableType validTableType))
            {
   
                throw new InvalidOperationException("Invalid table!");
            }


            if (validTableType == TableType.InsideTable)
            {
                this.table = new InsideTable(tableNumber, capacity);
            }
            else if (validTableType == TableType.OutsideTable)
            {
                this.table = new OutsideTable(tableNumber, capacity);
            }

            this.tables.Add(this.table);

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder output = new StringBuilder();

            foreach (ITable table in this.tables.Where(t => t.IsReserved == false))
            {
                output.AppendLine(table.GetFreeTableInfo());
            }

            return output.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {

            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            this.table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            decimal bill = this.table.GetBill();
            totalIncome += bill;
            this.table.Clear();

            return $"Table: {tableNumber}{Environment.NewLine}Bill: {bill:f2}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            this.table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            this.drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (table is null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            
            if (drink is null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkBrand, drinkBrand);
            }
   
            this.table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
            
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            this.table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            this.food = this.foods.FirstOrDefault(f => f.Name == foodName);

            if (table is null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (food is null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            this.table.OrderFood(food);
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            this.table = this.tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (table is null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            this.table.Reserve(numberOfPeople);
            return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
      

        }
    }
}
