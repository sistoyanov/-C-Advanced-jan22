using System;

namespace _01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine(CalculateSquare(num));
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }

        private static double CalculateSquare(int num)
        {
            if (num < 0)
            {
                throw new ArgumentException("Invalid number.");
            }
            else
            {
                return Math.Sqrt(num);
            }
        }
    }

    
}
