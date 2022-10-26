using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            List<User> users = new List<User>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] contestArg = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = contestArg[0];
                string contestPassword = contestArg[1];

                contests.Add(contest, contestPassword);
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] userArg = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string currentContest = userArg[0];
                string currentPassword = userArg[1];
                string currentUsername = userArg[2];
                double currentPoints = double.Parse(userArg[3]);

                if (contests.ContainsKey(currentContest) && contests[currentContest] == currentPassword)
                {

                    if (!users.Any(u => u.Name == currentUsername))
                    {
                        Dictionary<string, double> contestToAdd = new Dictionary<string, double>() { { currentContest, currentPoints } };
                        users.Add(new User(currentUsername, contestToAdd));
                    }

                    User userToCheck = users.FirstOrDefault(u => u.Name == currentUsername);

                    if (userToCheck.Contests.ContainsKey(currentContest))
                    {

                        if (userToCheck.Contests[currentContest] < currentPoints)
                        {
                            userToCheck.Contests[currentContest] = currentPoints;
                        }
                    }
                    else
                    {
                        userToCheck.Contests.Add(currentContest, currentPoints);
                    }

                }

            }

            double bestResult = 0;
            string bestUsername = string.Empty;

            foreach (User user in users)
            {
                double currentResult = user.Contests.Sum(u => u.Value);

                if (bestResult < currentResult)
                {
                    bestResult = currentResult;
                    bestUsername = user.Name;
                }
            }

            users = users.OrderBy(u => u.Name).ToList();

            Console.WriteLine($"Best candidate is {bestUsername} with total {bestResult} points.");
            Console.WriteLine("Ranking:");

            foreach (User user in users)
            {
                Console.WriteLine($"{user.Name}");

                Dictionary<string, double> result = user.Contests.OrderByDescending(v => v.Value).ToDictionary(x => x.Key, x => x.Value);

                foreach (var kvp in result)
                {
                    Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }

    class User
    {
        public User(string currentName, Dictionary<string, double> currentContests)
        {
            this.Name = currentName;
            this.Contests = currentContests;
        }

        public string Name { get; set; }
        public Dictionary<string, double> Contests { get; set; } = new Dictionary<string, double>();

    }

}