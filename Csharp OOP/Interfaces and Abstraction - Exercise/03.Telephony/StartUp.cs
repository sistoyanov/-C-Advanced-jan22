using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> numbers = new List<string>(Console.ReadLine().Split(" "));
            List<string> urls = new List<string>(Console.ReadLine().Split(" "));
            Stationary stationary = new Stationary();
            Smartphone smartphone = new Smartphone();

     
            foreach (var number in numbers)
            {
                try
                {
                    if (number.Count() == 10)
                    {
                        smartphone.Number = number;
                        Console.WriteLine(smartphone.Call());

                    }
                    else if (number.Count() == 7)
                    {
                        stationary.Number = number;
                        Console.WriteLine(stationary.Call());
                    }
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    smartphone.Url = url;
                    Console.WriteLine(smartphone.Browse());
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
