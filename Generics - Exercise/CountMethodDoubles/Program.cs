using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CountMethodDoubles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Box<double>> boxList = new List<Box<double>>();

            for (int i = 0; i < count; i++)
            {
                Box<double> newBox = new Box<double>(double.Parse(Console.ReadLine()));
                boxList.Add(newBox);
            }

            double comperer = double.Parse(Console.ReadLine());
            //int count = GetValuesGreaterThan(boxList, comperer);
        
        }

        //public static int GetValuesGreaterThan<T>(List<T> inputList, T comperer) where T : IComparable<T>
        //{
        //    return inputList.Count(item => item.CompareTo(comperer) > 0);
        //}
    }
}
