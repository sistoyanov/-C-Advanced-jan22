using System;
using System.Collections.Generic;
using System.Reflection;

namespace _02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;


            List<int> numbers = new List<int>();

            while (numbers.Count < 10)
            {
                int currentNum;

                try
                {
                    currentNum = ReadNumber(start, end);

                    if (currentNum > start)
                    {
                        start = currentNum;
                    }

                    numbers.Add(currentNum);

                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Your number is not in range {start} - 100!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }

            }

            Console.WriteLine(String.Join(", ", numbers));

        }

        private static int ReadNumber(int start, int end)
        {
            int currentNum = int.Parse(Console.ReadLine());

            if (currentNum <= start || currentNum >= end)
            {
                throw new ArgumentOutOfRangeException();
            }

            return currentNum;

        }
    }
}
