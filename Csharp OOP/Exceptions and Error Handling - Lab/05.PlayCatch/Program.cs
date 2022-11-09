using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int exeptionCount = 0;

            while(exeptionCount < 3)
            {
                string[] commandArg = Console.ReadLine().Split(' ');
                string command = commandArg[0];

                try
                {

                    if (command == "Replace")
                    {
                        int index = int.Parse(commandArg[1]);
                        int element = int.Parse(commandArg[2]);
                        int oldElement = numbers[index];
                        numbers.RemoveAt(index);
                        numbers.Insert(index, element);

                    }
                    else if (command == "Print")
                    {
                        int startIndex = int.Parse(commandArg[1]);
                        int endIndex = int.Parse(commandArg[2]);
                        List<int> subListOfNumber = numbers.GetRange(startIndex, endIndex);
                        Console.WriteLine(string.Join(", ", subListOfNumber));
                    }
                    else if (command == "Show")
                    {
                        int showIndex = int.Parse(commandArg[1]);
                        Console.WriteLine(numbers[showIndex]);
                    }
                }
                catch (ArgumentException)
                {

                    Console.WriteLine("The index does not exist!");
                    exeptionCount++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exeptionCount++;
                }

                if (exeptionCount == 3)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
