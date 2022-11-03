using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            IBuyer buyer = null;
            List<IBuyer> buyerList = new List<IBuyer>();

            for (int i = 0; i < number; i++)
            {
                string[] byerDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string byerName = byerDetails[0];
                int byerAge = int.Parse(byerDetails[1]);

                if (byerDetails.Count() == 4)
                {
                    string citizenId = byerDetails[2];
                    string citizenBirthDate = byerDetails[3];

                    buyer = new Citizen(byerName, byerAge, citizenId, citizenBirthDate);
                    buyerList.Add(buyer);
                }
                else if (byerDetails.Count() == 3)
                {
                    string rebelGroup = byerDetails[2];

                    buyer = new Rebel(byerName, byerAge, rebelGroup);
                    buyerList.Add(buyer);
                }
            }

            string input = string.Empty;
            int foodSum = 0;

            while ((input = Console.ReadLine()) != "End")
            {
                string currentByerName = input;
                IBuyer currentByer = buyerList.FirstOrDefault(b => b.Name == currentByerName);

                if (currentByer != null)
                {
                    currentByer.BuyFood();
                }
            }

            foreach (var item in buyerList)
            {
                foodSum += item.Food;
            }

            Console.WriteLine(foodSum);
        }
    }
}
