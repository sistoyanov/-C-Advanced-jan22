
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private IRepository<IDelicacy> delicacyMenu;
        private IRepository<ICocktail> cocktailMenu;
        private int capacity;
        private double currentBill = 0;
        private double turnover = 0;
        private bool isReserved = false;

        public Booth(int boothId, int capacity)
        {
            this.BoothId = boothId;
            this.Capacity = capacity;
            this.delicacyMenu = new DelicacyRepository();
            this.cocktailMenu = new CocktailRepository();
        }

        public int BoothId { get; private set; }

        public int Capacity
        {
            get { return this.capacity; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }

                this.capacity = value; 
            }
        }


        public IRepository<IDelicacy> DelicacyMenu => this.delicacyMenu;

        public IRepository<ICocktail> CocktailMenu => this.cocktailMenu;

        public double CurrentBill
        {
            get { return this.currentBill; }
            private set
            { 
                this.currentBill = value;
            }
        }

        public double Turnover
        {
            get { return this.turnover; }
            private set
            {
                this.turnover = value;
            }
        }

        public bool IsReserved
        {
            get { return this.isReserved; }
            private set
            {
                this.isReserved = value;
            }
        }

        public void UpdateCurrentBill(double amount)
        {
            this.CurrentBill += amount;
        }

        public void Charge()
        {
            this.Turnover += this.CurrentBill;
            this.CurrentBill = 0;
        }

        public void ChangeStatus() => IsReserved = !IsReserved;

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Booth: {this.BoothId}")
                  .AppendLine($"Capacity: {this.Capacity}")
                  .AppendLine($"Turnover: {this.Turnover:f2} lv");

            output.AppendLine($"-Cocktail menu:");

            foreach (ICocktail cocktail in this.cocktailMenu.Models)
            {
                output.AppendLine($"--{cocktail.ToString()}");
            }

            output.AppendLine($"-Delicacy menu:");

            foreach (IDelicacy delicacy in this.delicacyMenu.Models)
            {
                output.AppendLine($"--{delicacy.ToString()}");
            }


            return output.ToString().TrimEnd();
        }
    }
}
