using System;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> set = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandArg = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string commandType = commandArg[0];
                string carLicense = commandArg[1];

                if (commandType == "IN")
                {
                    set.Add(carLicense);
                }
                else if (commandType == "OUT")
                {
                    set.Remove(carLicense);
                }
            }

            if (set.Count > 0)
            {
                foreach (var license in set)
                {
                    Console.WriteLine(license);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
