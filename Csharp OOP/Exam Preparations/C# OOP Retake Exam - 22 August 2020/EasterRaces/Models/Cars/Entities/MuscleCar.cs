namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double MuscleCarCubicCentimeters = 5000;
        private const int MuscleCarMinimumHorsepower = 400;
        private const int MuscleCarMaximumHorsepower = 600;
        public MuscleCar(string model, int horsePower) : base(model, horsePower, MuscleCarCubicCentimeters, MuscleCarMinimumHorsepower, MuscleCarMaximumHorsepower)
        {
        }

    }
}
