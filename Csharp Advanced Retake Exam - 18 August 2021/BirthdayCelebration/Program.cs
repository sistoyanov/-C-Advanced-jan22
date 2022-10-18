using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] guestDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] platesDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<int> guests = new List<int>(guestDetails);
            Stack<int> plates = new Stack<int>(platesDetails);
            int wasteFood = 0;

            while (guests.Count > 0 && plates.Count > 0)
            {
                int currentPlate = plates.Pop();
                guests[0] -= currentPlate;

                if (guests[0] <= 0)
                {
                    wasteFood += Math.Abs(guests[0]);
                    guests.RemoveAt(0);
                    
                }
            }

            if (plates.Count > 0)
            {
                Console.WriteLine($"Plates: {String.Join(" ", plates)}");
            }
            else if (guests.Count > 0)
            {
                Console.WriteLine($"Guests: {String.Join(" ", guests)}");
            }

            Console.WriteLine($"Wasted grams of food: {wasteFood}");
        }
    }
}
