using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers{
    public class ProfessionalRacer : Racer
    {
        private const int ProfessionalRacerDrivingExperience = 30;
        private const string ProfessionalRacerRacingBehavior = "strict";
        public ProfessionalRacer(string username, ICar car) : base(username, ProfessionalRacerRacingBehavior, ProfessionalRacerDrivingExperience, car)
        {
        }

        public override void Race()
        {
            this.DrivingExperience += 10;
        }
    }
}
