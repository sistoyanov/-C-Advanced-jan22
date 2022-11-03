using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance 
        { 
            get => this.endurance;
            private set
            {
                if (IsInValid(value))
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.InvalidStatMessage, nameof(this.Endurance)));
                }

                this.endurance = value;
            }
        }

        public int Sprint 
        { 
            get => this.sprint;
            private set
            {
                if (IsInValid(value))
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.InvalidStatMessage, nameof(this.Sprint)));
                }

                this.sprint = value;
            }
        }

        public int Dribble 
        { 
            get => this.dribble;
            private set
            {
                if (IsInValid(value))
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.InvalidStatMessage, nameof(this.Dribble)));
                }

                this.dribble = value;
            }
        }

        public int Passing 
        { 
            get => this.passing;
            private set
            {
                if (IsInValid(value))
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.InvalidStatMessage, nameof(this.Passing)));
                }

                this.passing = value;
            }
        }

        public int Shooting 
        { 
            get => this.shooting;
            private set
            {
                if (IsInValid(value))
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.InvalidStatMessage, nameof(this.Shooting)));
                }

                this.shooting = value;
            }
        }

        private bool IsInValid(int value) => value < 0 || value > 100;
    }
}
