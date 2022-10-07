using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<VLogger> vLogersList = new List<VLogger>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] commandArg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string vLogerName = commandArg[0];
                string action = commandArg[1];

                if (action == "joined")
                {
                    VLogger newVLoger = new VLogger(vLogerName);

                    if (!vLogersList.Any(v => v.Name == vLogerName))
                    {
                        vLogersList.Add(newVLoger);
                    }
                }
                else if (action == "followed")
                {
                    string vLogerToFollow = commandArg[2];

                    VLogger currentVLoger = vLogersList.FirstOrDefault(v => v.Name == vLogerName);
                    VLogger currenVLogerToFollow = vLogersList.FirstOrDefault(v => v.Name == vLogerToFollow);



                    if (currentVLoger != null && currenVLogerToFollow != null)
                    {
                        if (vLogerName != vLogerToFollow && !currenVLogerToFollow.Followers.Contains(vLogerName))
                        {
                            currenVLogerToFollow.Followers.Add(vLogerName);
                            currentVLoger.Following.Add(vLogerToFollow);
                        }
                    }
                }
            }

            vLogersList = vLogersList.OrderByDescending(v => v.Followers.Count).ThenBy(v => v.Following.Count).ToList();

            Console.WriteLine($"The V-Logger has a total of {vLogersList.Count} vloggers in its logs.");

            for (int i = 0; i < vLogersList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {vLogersList[i]} : {vLogersList[i].Followers.Count} followers, {vLogersList[i].Following.Count} following");

                if (i == 0 )
                {
                    foreach (var follower in vLogersList[i].Followers.OrderBy(f => f))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }

        }
    }

    internal class VLogger
    {
        public VLogger(string name)
        {
            this.Name = name;
            this.Followers = new List<string>();
            this.Following = new List<string>();
        }

        public string Name { get; set; }
        public List<string> Followers { get; set; }
        public List<string> Following { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
