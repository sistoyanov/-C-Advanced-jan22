using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> players;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            players = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return players.Count; } }

        public void AddPlayer(Player player)
        {
            if (Count < Capacity)
            {
                players.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            return players.Remove(players.FirstOrDefault(p => p.Name == name));
        }

        public void PromotePlayer(string name)
        {
            Player playerToPromote = players.FirstOrDefault(p => p.Name == name);

            if (playerToPromote != null && playerToPromote.Rank != "Member")
            {
                playerToPromote.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player playerToPromote = players.FirstOrDefault(p => p.Name == name);

            if (playerToPromote != null && playerToPromote.Rank != "Trial")
            {
                playerToPromote.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string _class)
        {
            Player[] output = players.FindAll(p => p.Class == _class).ToArray();
            players.RemoveAll(p => p.Class == _class);

            return output;
        }

        public string Report()
        {
            StringBuilder _out = new StringBuilder();
            _out.AppendLine($"Players in the guild: {Name}");

            foreach (var player in players)
            {
                _out.AppendLine(player.ToString());
            }

            return _out.ToString().TrimEnd();
        }
    }
}
