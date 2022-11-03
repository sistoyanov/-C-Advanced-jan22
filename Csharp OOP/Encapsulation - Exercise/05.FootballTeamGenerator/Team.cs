using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;
        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.InvalidNameMessage));
                }

                this.name = value;
            }
        }

        public int Raiting => this.players.Count > 0 ? (int)Math.Round(this.players.Average(p => p.SkillLevel), 0) : 0;

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = this.players.FirstOrDefault(p => p.Name == playerName);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException(String.Format(ExeptionMessages.InvalidPlayerMessage, playerName, this.Name));
            }
            
            this.players.Remove(playerToRemove);
        }
    }
}
