using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> languages = new SortedDictionary<string, int>();
            SortedDictionary<string, List<int>> users = new SortedDictionary<string, List<int>>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] inputDetails = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string userName = inputDetails[0];
                string command = inputDetails[1];
                

                if (command != "banned")
                {
                    int userPoints = int.Parse(inputDetails[2]);

                    if (!languages.ContainsKey(command))
                    {
                        languages.Add(command, 0);
                    }

                    if (!users.ContainsKey(userName))
                    {
                        users.Add(userName, new List<int>());
                        users[userName].Add(userPoints);
                        languages[command]++;
                    }
                    else
                    {
                        users[userName].Add(userPoints);
                        languages[command]++;
                    }
                    
                }
                else
                {
                    users.Remove(userName);
                }

            }

            Dictionary<string, int> usersToPrint = new Dictionary<string, int>();

            foreach (var user in users)
            {
                usersToPrint.Add(user.Key, user.Value.Max());
            }

            usersToPrint = usersToPrint.OrderByDescending(v => v.Value).ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine("Results:");

            foreach (var userToPrint in usersToPrint)
            {
                Console.WriteLine($"{userToPrint.Key} | {userToPrint.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var language in languages)
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }

        }
    }
}
