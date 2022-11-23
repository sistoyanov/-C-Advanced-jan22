namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double SportsCarCubicCentimeters = 3000;
        private const int SportsCarMinimumHorsepower = 250;
        private const int SportsCarMaximumHorsepower = 450;

        public SportsCar(string model, int horsePower) : base(model, horsePower, SportsCarCubicCentimeters, SportsCarMinimumHorsepower, SportsCarMaximumHorsepower)
        {
        }
    }
}
