using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;

        public Team(string name, int openPositions, char group)
        {
            players = new List<Player>();
            Name = name;
            OpenPositions = openPositions;
            Group = group;
        }

        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count => players.Count;

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }
            else if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }
            else
            {
                if (OpenPositions > 0)
                {
                    players.Add(player);
                    OpenPositions -= 1;
                    return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
                }
                else
                {
                    return "There are no more open positions.";
                }
            }
        }

        public bool RemovePlayer(string name)
        {
            Player playerToRemove = players.FirstOrDefault(p => p.Name == name);

            if (playerToRemove != null)
            {
                players.Remove(playerToRemove);
                OpenPositions++;
                return true;
            }

            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int count = players.Where(p => p.Position == position).Count();
            players.RemoveAll(p => p.Position == position);
            OpenPositions += count;
            return count;
        }

        public Player RetirePlayer(string name)
        {
            Player playerToRetire = players.FirstOrDefault(p => p.Name == name);

            if (playerToRetire != null)
            {
                playerToRetire.Retired = true;
            }

            return playerToRetire;
        }

        public List<Player> AwardPlayers(int games) => players.FindAll(p => p.Games >= games).ToList();

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            foreach (Player player in players.Where(p => p.Retired == false))
            {
                output.AppendLine(player.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
