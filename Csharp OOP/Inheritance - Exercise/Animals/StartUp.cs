using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animalList = new List<Animal>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Beast!")
            {
                string[] animalDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = animalDetails[0];
                int age = int.Parse(animalDetails[1]);
                string gneder = animalDetails[2];
                
                if (input == "Dog")
                {
                    try
                    {
                        Dog dog = new Dog (name, age, gneder);
                        animalList.Add(dog);
                    }
                    catch (Exception exception)
                    {

                        Console.WriteLine(exception.Message);
                    }
                }
                else if (input == "Cat")
                {
                    try
                    {
                        Cat cat = new Cat(name, age, gneder);
                        animalList.Add(cat);
                    }
                    catch (Exception exception)
                    {

                        Console.WriteLine(exception.Message);
                    }
                }
                else if (input == "Frog")
                {
                    try
                    {
                        Frog frog = new Frog (name, age, gneder);
                        animalList.Add (frog);
                    }
                    catch (Exception exception)
                    {

                        Console.WriteLine(exception.Message);
                    }
                }
                else if (input == "Kitten")
                {
                    try
                    {
                        Kitten kitten = new Kitten(name, age);
                        animalList.Add(kitten);
                    }
                    catch (Exception exception)
                    {

                        Console.WriteLine(exception.Message);
                    }
                }
                else if (input == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age);
                    animalList.Add(tomcat);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            foreach (var animal in animalList)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
