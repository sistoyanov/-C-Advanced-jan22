using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        public Player(string name, int playerEndurance, int playerSprint, int playerDribble, int playerPassing, int playerShooting)
        {
            this.Name = name;
            this.Stats = new Stats(playerEndurance, playerSprint, playerDribble, playerPassing, playerShooting);
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

        public Stats Stats { get; private set; }

        public double SkillLevel => (Stats.Endurance + Stats.Sprint + Stats.Dribble + Stats.Passing + Stats.Shooting) / 5.0;
   
    }
}
