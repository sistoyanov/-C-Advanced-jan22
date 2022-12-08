using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IHotel> hotels;

        public Controller()
        {
            this.hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = this.hotels.Select(hotelName);

            if (hotel != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }
            else
            {
                hotel = new Hotel(hotelName, category);
                this.hotels.AddNew(hotel);
                return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
            }
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = this.hotels.Select(hotelName);
            IRoom room;

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName == "DoubleBed")
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == "Studio")
            {
                room = new Studio();
            }
            else if (roomTypeName == "Apartment")
            {
                room = new Apartment();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            if (hotel.Rooms.Select(roomTypeName) != null)
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);
            }
            else
            {
                hotel.Rooms.AddNew(room);
                return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
            }

        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = this.hotels.Select(hotelName);
            IRoom room;

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName == "DoubleBed" || roomTypeName == "Studio" || roomTypeName == "Apartment")
            {
                room = hotel.Rooms.Select(roomTypeName);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            if (room == null)
            {
                return string.Format(OutputMessages.RoomTypeNotCreated);
            }

            if (room.PricePerNight == 0)
            {
                room.SetPrice(price);
                return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }

        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {

            if (!this.hotels.All().Any(h => h.Category == category))
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            List<IHotel> hotels = this.hotels.All().OrderBy(h => h.FullName).ToList();

            foreach (IHotel hotel in hotels)
            {

                IRoom roomReady = hotel.Rooms.All().Where(p => p.PricePerNight > 0).Where(c => c.BedCapacity >= adults + children).OrderBy(b => b.BedCapacity).FirstOrDefault();

                if (roomReady != null)
                {
                    int bookingNumber = this.hotels.All().Sum(x => x.Bookings.All().Count) + 1;
                    Booking booking = new Booking(roomReady, duration, adults, children, bookingNumber);
                    hotel.Bookings.AddNew(booking);

                    return string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName);
                }
            }

            return string.Format(OutputMessages.RoomNotAppropriate);
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = this.hotels.Select(hotelName);
            StringBuilder output = new StringBuilder();

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            output.AppendLine($"Hotel name: {hotelName}")
                  .AppendLine($"--{hotel.Category} star hotel")
                  .AppendLine($"--Turnover: {hotel.Turnover:F2} $")
                  .AppendLine($"--Bookings:")
                  .AppendLine();

            if (hotel.Bookings.All().Count > 0)
            {

                foreach (IBooking booking in hotel.Bookings.All())
                {
                    output.AppendLine(booking.BookingSummary())
                          .AppendLine();
                }
            }
            else
            {
                output.AppendLine("none");
            }

            return output.ToString().TrimEnd();

        }

    }
}
