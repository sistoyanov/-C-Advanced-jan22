using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private readonly ICollection<IHotel> hotelRepository;

        public HotelRepository()
        {
            this.hotelRepository = new List<IHotel>();
        }

        public void AddNew(IHotel model) => this.hotelRepository.Add(model);

        public IReadOnlyCollection<IHotel> All() => this.hotelRepository as IReadOnlyCollection<IHotel>;

        public IHotel Select(string hotelName) => this.hotelRepository.FirstOrDefault(h => h.FullName == hotelName);
    }
}
