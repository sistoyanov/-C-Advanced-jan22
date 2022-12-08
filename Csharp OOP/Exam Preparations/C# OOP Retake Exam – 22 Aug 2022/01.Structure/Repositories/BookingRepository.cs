using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private readonly ICollection<IBooking> bookingRepository;

        public BookingRepository()
        {
            this.bookingRepository = new List<IBooking>();
        }

        public void AddNew(IBooking model) => this.bookingRepository.Add(model);

        public IReadOnlyCollection<IBooking> All() => this.bookingRepository as IReadOnlyCollection<IBooking>;

        public IBooking Select(string bookingNumberToString) => this.bookingRepository.FirstOrDefault(b => b.BookingNumber.ToString() == bookingNumberToString);
    }
}
