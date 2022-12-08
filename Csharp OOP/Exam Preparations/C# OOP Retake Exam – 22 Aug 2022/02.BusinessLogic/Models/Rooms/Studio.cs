namespace BookingApp.Models.Rooms
{
    public class Studio : Room
    {
        private const int StudioCapacity = 4;
        public Studio() : base(StudioCapacity)
        {
        }
    }
}
