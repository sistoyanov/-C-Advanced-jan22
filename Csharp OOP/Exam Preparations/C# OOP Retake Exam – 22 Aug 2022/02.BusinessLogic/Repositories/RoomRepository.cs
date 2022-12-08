using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private readonly ICollection<IRoom> roomRepository;

        public RoomRepository()
        {
            this.roomRepository = new List<IRoom>();
        }

        public void AddNew(IRoom model) => this.roomRepository.Add(model);

        public IReadOnlyCollection<IRoom> All() => this.roomRepository as IReadOnlyCollection<IRoom>;

        public IRoom Select(string roomTypeName) => this.roomRepository.FirstOrDefault(r => r.GetType().Name == roomTypeName);

    }
}
