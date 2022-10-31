using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
            List<Product> productList = new List<Product>();
            string[] persons = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] products = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (string person in persons)
            {
                string[] personDetails = person.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string personName = personDetails[0];
                decimal personMoney = decimal.Parse(personDetails[1]);

                try
                {
                    Person currentPerson = new Person(personName, personMoney);
                    personList.Add(currentPerson);
                }
                catch (ArgumentException exception)
                {

                    Console.WriteLine(exception.Message);
                    return;
                }
            }

            foreach (string product in products)
            {
                string[] productDetails = product.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string productName = productDetails[0];
                decimal productCost = decimal.Parse(productDetails[1]);

                try
                {
                    Product currentProduct = new Product (productName, productCost);
                    productList.Add(currentProduct);
                    
                }
                catch (ArgumentException exception)
                {

                    Console.WriteLine(exception.Message);
                    return;
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] purchase = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person buyer = personList.FirstOrDefault(b => b.Name == purchase[0]);
                Product productToBuy = productList.FirstOrDefault(p => p.Name == purchase[1]);
                buyer.BuyProduct(productToBuy);
            }

            foreach (var person in personList)
            {
                Console.WriteLine(person);
            }

        }
    }
}
