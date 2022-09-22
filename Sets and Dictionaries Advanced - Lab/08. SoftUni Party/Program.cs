using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> guestList = new HashSet<string>();


            while ((input = Console.ReadLine()) != "PARTY")
            {
                guestList.Add(input);
            }

            while ((input = Console.ReadLine()) != "END")
            {
                guestList.Remove(input);
            }

            Console.WriteLine(guestList.Count);

            //foreach (var guest in guestList)
            //{
            //    if (guest.Any(char.IsDigit))
            //    {
            //        Console.WriteLine(guest);
            //    }

            //    guestList.Remove(guest);
            //}

            //foreach (var guest in guestList)
            //{
            //    if (guest.Any(char.IsLetter))
            //    {
            //        Console.WriteLine(guest);
            //    }
            //}

            foreach (var item in guestList)
            {
                char[] ch = item.ToCharArray();
                if (char.IsDigit(ch[0]))
                {
                    Console.WriteLine(item);
                }
            }
            foreach (var item in guestList)
            {
                char[] ch = item.ToCharArray();
                if (char.IsLetter(ch[0]))
                {
                    Console.WriteLine(item);
                }
            }

        }
    }
}
