using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            string output = string.Empty;
            
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                output = OutputMessages.RaceCannotBeCompleted;
            }
            else if (!racerOne.IsAvailable())
            {
                output = string.Format(string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username));
            }
            else if (!racerTwo.IsAvailable())
            {
                output = string.Format(string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username));
            }
            else
            {
                double racerOnechanceOfWinning = ChanceOfWinning(racerOne);
                double racerTwochanceOfWinning = ChanceOfWinning(racerTwo);

                racerOne.Race();
                racerTwo.Race();

                if (racerOnechanceOfWinning > racerTwochanceOfWinning)
                {
                    output = string.Format(string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username));
                }
                else
                {
                    output = string.Format(string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username));
                }

            }

            return output;
        }

        private double ChanceOfWinning(IRacer racer)
        {
            double racingBehaviorMultiplier = 0;

            if (racer.RacingBehavior == "strict")
            {
                racingBehaviorMultiplier = 1.2;
            }
            else if (racer.RacingBehavior == "aggressive")
            {
                racingBehaviorMultiplier = 1.1;
            }

            double chanceOfWinning = racer.Car.HorsePower * racer.DrivingExperience * racingBehaviorMultiplier;
            
            return chanceOfWinning;
        }
    }
}
