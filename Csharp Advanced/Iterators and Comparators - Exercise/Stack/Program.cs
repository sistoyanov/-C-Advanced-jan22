using System;
using System.Linq;

namespace Stack
{
    public class StarUp
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputDetails = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string action = inputDetails[0];

                if (action == "Push")
                {
                    string[] itemsToPush = inputDetails.Skip(1).ToArray();
                    foreach (var item in itemsToPush)
                    {
                        stack.Push(item);
                    }
                }
                else if (action == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException exception)
                    {

                        Console.WriteLine(exception.Message);
                    }
                }
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
