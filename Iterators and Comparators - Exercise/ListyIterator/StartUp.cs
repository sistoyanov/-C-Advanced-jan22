using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string items = Console.ReadLine();
            ListyIterator<string> collection = new ListyIterator<string>(items.Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList());
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string commad = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).First();
                
                if (commad == "Move")
                {
                    Console.WriteLine(collection.Move());
                }
                else if (commad == "Print")
                {
                    
                    try
                    {
                        collection.Print();
                    }
                    catch (Exception exception)
                    {

                        Console.WriteLine(exception.Message);
                    }
                }
                else if (commad == "HasNext")
                {
                    Console.WriteLine(collection.HasNext());
                }
            }
        }
    }
}
