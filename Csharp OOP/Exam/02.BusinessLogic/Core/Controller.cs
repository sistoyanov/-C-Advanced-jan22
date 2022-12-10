using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller()
        {
            this.booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = this.booths.Models.Count + 1;
            Booth newBooth = new Booth(boothId, capacity);

            this.booths.AddModel(newBooth);
            return string.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            IDelicacy delicacy;

            if (booth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == "Stolen")
            {
                delicacy = new Stolen(delicacyName);
            }
            else
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            booth.DelicacyMenu.AddModel(delicacy);
            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            ICocktail cocktail;

            if (booth.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            if (size == "Small" || size == "Middle" || size == "Large")
            {
                if (cocktailTypeName == "MulledWine")
                {
                    cocktail = new MulledWine(cocktailName, size);
                }
                else if (cocktailTypeName == "Hibernation")
                {
                    cocktail = new Hibernation(cocktailName, size);
                }
                else
                {
                    return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
                }
            }
            else
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            booth.CocktailMenu.AddModel(cocktail);
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            List<IBooth> orderedBooths = this.booths.Models.Where(b => b.IsReserved == false && b.Capacity >= countOfPeople).OrderBy(b => b.Capacity).ThenByDescending(b => b.BoothId).ToList();
            IBooth boothToReserve = orderedBooths.FirstOrDefault();

            if (boothToReserve == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            boothToReserve.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, boothToReserve.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            IDelicacy delicacy = null;
            ICocktail cocktail = null;

            string[] orderDetails = order.Split("/", StringSplitOptions.RemoveEmptyEntries);
            string itemTypeName = orderDetails[0];
            string itemName = orderDetails[1];
            int count = int.Parse(orderDetails[2]);
            string size = string.Empty;

            if (itemTypeName == "MulledWine" || itemTypeName == "Hibernation")
            {
                size = orderDetails[3];
            }

            if (itemTypeName == "MulledWine" || itemTypeName == "Hibernation" || itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                if (itemTypeName == "MulledWine" || itemTypeName == "Hibernation")
                {
                    cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == itemName);

                    if (cocktail == null)
                    {
                        return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                    }

                }
                else if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
                {
                    delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == itemName);

                    if (delicacy == null)
                    {
                        return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                    }

                }
            }
            else
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }


            if (cocktail != null)
            {
                if (cocktail.Size != size)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, size, itemName);
                }

                booth.UpdateCurrentBill(cocktail.Price * count);
                
            }
            else if (delicacy != null)
            {
                booth.UpdateCurrentBill(delicacy.Price * count);

            }

            return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, count, itemName);
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            StringBuilder output = new StringBuilder();

            double bill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();

            output.AppendLine($"Bill {bill:f2} lv");
            output.AppendLine($"Booth {booth.BoothId} is now available!");

            return output.ToString().TrimEnd();
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            return booth.ToString();
        }



    }
}
