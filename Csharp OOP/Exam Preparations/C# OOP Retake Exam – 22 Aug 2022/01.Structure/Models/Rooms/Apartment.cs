namespace BookingApp.Models.Rooms
{
    public class Apartment : Room
    {
        private const int ApartmentCapacity = 6;
        public Apartment() : base(ApartmentCapacity)
        {
        }
    }
}
