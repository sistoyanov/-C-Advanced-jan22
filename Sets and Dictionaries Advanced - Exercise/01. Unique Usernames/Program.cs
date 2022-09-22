﻿using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                set.Add(input);
            }

            foreach (var name in set)
            {
                Console.WriteLine(name);
            }
        }
    }
}
