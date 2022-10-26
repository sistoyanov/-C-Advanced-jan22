using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackOfStrings = new StackOfStrings();
            Console.WriteLine(stackOfStrings.IsEmpty()); 
            stackOfStrings.AddRange("2", "1", "0") ;
            Console.WriteLine(stackOfStrings.IsEmpty());
        }
    }
}
