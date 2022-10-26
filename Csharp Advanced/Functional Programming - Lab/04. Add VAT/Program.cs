using System;
using System.Linq;

namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            foreach (var num in nums)
            {
                Console.WriteLine($"{num * 1.2:f2}");
            }
        }
    }
}
