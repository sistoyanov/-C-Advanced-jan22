using System;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] personDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] drinkDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] numbersDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Tuple<string, string> person = new Tuple<string, string>
            {
                Item1 = $"{personDetails[0]} {personDetails[1]}",
                Item2 = $"{personDetails[2]}"
            };

            Tuple<string, int> drink = new Tuple<string, int>
            {
                Item1 = $"{drinkDetails[0]}",
                Item2 = int.Parse(drinkDetails[1])
            };

            Tuple<int, double> numbers = new Tuple<int, double>
            {
                Item1 = int.Parse(numbersDetails[0]),
                Item2 = double.Parse(numbersDetails[1])
            };

            Console.WriteLine(person);
            Console.WriteLine(drink);
            Console.WriteLine(numbers);
        }
    }
}
