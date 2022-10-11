using System;
using System.Linq;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] drinkDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] bankDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Tuple<string, string, string> person = new Tuple<string, string, string>
            {
                Item1 = $"{personDetails[0]} {personDetails[1]}",
                Item2 = personDetails[2],
                Item3 = (personDetails.Length > 4) ? $"{personDetails[3]} {personDetails[4]}" : personDetails[3]
            };

            Tuple<string, int, bool> drink = new Tuple<string, int, bool>
            {
                Item1 = drinkDetails[0],
                Item2 = int.Parse(drinkDetails[1]),
                Item3 = (drinkDetails[2] == "drunk")
            };

            Tuple<string, double, string> numbers = new Tuple<string, double, string>
            {
                Item1 = bankDetails[0],
                Item2 = double.Parse(bankDetails[1]),
                Item3 = bankDetails[2]
            };

            Console.WriteLine(person);
            Console.WriteLine(drink);
            Console.WriteLine(numbers);
        }
    }
}
