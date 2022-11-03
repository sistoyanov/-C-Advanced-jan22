using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class ExeptionMessages
    {
        public const string InvalidStatMessage = "{0} should be between 0 and 100.";
        public const string InvalidNameMessage = "A name should not be empty.";
        public const string InvalidPlayerMessage = "Player {0} is not in {1} team.";
        public const string InvalidTeamMessage = "Team {0} does not exist.";
    }
}
