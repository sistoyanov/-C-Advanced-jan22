using System;
using System.Globalization;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dough dough = null;
            Topping topping = null;
            Pizza pizza = null;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputDetails = input.Split(" ").Select(c => c.ToLower()).ToArray();

                try
                {

                    if (inputDetails[0] == "pizza")
                    {
                        string pizzaName = inputDetails[1];
                        pizza = new Pizza(pizzaName);
                    }
                    else if (inputDetails[0] == "dough")
                    {
                        string flourType = inputDetails[1];
                        string bakingTechnique = inputDetails[2];
                        double doughWeight = double.Parse(inputDetails[3]);

                        dough = new Dough(flourType, bakingTechnique, doughWeight);
                        pizza.Dough = dough;
                    }
                    else if (inputDetails[0] == "topping")
                    {
                        string toppingType = inputDetails[1];
                        double toppingWeight = double.Parse(inputDetails[2]);

                        topping = new Topping(toppingType, toppingWeight);
                        pizza.AddTopping(topping);
                    }

       

                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                    return;
                }

            }

            Console.WriteLine(pizza);
        }

    }
}
