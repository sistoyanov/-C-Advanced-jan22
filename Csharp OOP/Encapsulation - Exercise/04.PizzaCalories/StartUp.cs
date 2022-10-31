using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputDetails = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (inputDetails[0] == "Dough")
                {
                    string flourType = inputDetails[1];
                    string bakingTechnique = inputDetails[2];
                    double doughWeight = double.Parse(inputDetails[3]);

                    try
                    {
                        Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
                        Console.WriteLine($"{dough.DoughCaloriesPerGram:f2}");
                    }
                    catch (ArgumentException ae)
                    {

                        Console.WriteLine(ae.Message);
                    }
                }
                else if (inputDetails[0] == "Topping")
                {
                    string toppingType = inputDetails[1];
                    double toppingWeight = double.Parse(inputDetails[2]);

                    try
                    {
                        Topping topping = new Topping(toppingType, toppingWeight);
                        Console.WriteLine($"{topping.ToppingCaloriesPerGram:f2}");
                    }
                    catch (ArgumentException ae)
                    {

                        Console.WriteLine(ae.Message);
                    }
                }
            }
        }
    }
}
