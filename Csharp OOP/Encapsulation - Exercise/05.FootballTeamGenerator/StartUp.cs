using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Team> teams = new List<Team>();

            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] inputDetails = input.Split(';');
                    string command = inputDetails[0];
                    string teamName = inputDetails[1];

                    if (command == "Team")
                    {
                        Team newTeam = new Team(teamName);
                        teams.Add(newTeam);
                    }
                    else if (command == "Add")
                    {
                        Team joiningTeam = teams.FirstOrDefault(t => t.Name == teamName);

                        if (joiningTeam == null)
                        {
                            throw new InvalidOperationException(String.Format(ExeptionMessages.InvalidTeamMessage, teamName));
                        }

                        string playerName = inputDetails[2];
                        int playerEndurance = int.Parse(inputDetails[3]);
                        int playerSprint = int.Parse(inputDetails[4]);
                        int playerDribble = int.Parse(inputDetails[5]);
                        int playerPassing = int.Parse(inputDetails[6]);
                        int playerShooting = int.Parse(inputDetails[7]);

                        Player newPlayer = new Player(playerName, playerEndurance, playerSprint, playerDribble, playerPassing, playerShooting);
                        joiningTeam.AddPlayer(newPlayer);
                    }
                    else if (command == "Remove")
                    {
                        Team teamToRemoveFrom = teams.FirstOrDefault(t => t.Name == teamName);

                        if (teamToRemoveFrom == null)
                        {
                            throw new InvalidOperationException(String.Format(ExeptionMessages.InvalidTeamMessage, teamName));
                        }

                        string playerToRemoveName = inputDetails[2];
                        teamToRemoveFrom.RemovePlayer(playerToRemoveName);
                    }
                    else if (command == "Rating")
                    {
                        Team teamToRate = teams.FirstOrDefault(t => t.Name == teamName);

                        if (teamToRate == null)
                        {
                            throw new InvalidOperationException(String.Format(ExeptionMessages.InvalidTeamMessage, teamName));
                        }

                        int rating = teamToRate.Raiting;
                        Console.WriteLine($"{teamName} - {rating}");
                    }
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }


            }
        }
     
    }
}
