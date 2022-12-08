using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel hotel;

        [SetUp]
        public void Setup()
        {
            string fullName = "Boro";
            int category = 5;
            this.hotel = new Hotel(fullName, category);
        }

        [Test]
        public void Test_HotelConstructorShouldSetName()
        {
            string expectedFullName = "Boro";
            string actualFullName = this.hotel.FullName;

            Assert.AreEqual(expectedFullName, actualFullName);
        }

        [Test]
        public void Test_HotelConstructorShouldSetCategory()
        {
            int expectedCategory = 5;
            int actualCategory = this.hotel.Category;

            Assert.AreEqual(expectedCategory, actualCategory);
        }

        [Test]
        public void Test_HotelConstructorShouldSetTurnover()
        {
            double expectedTurnover = 0;
            double actualTurnover = this.hotel.Turnover;

            Assert.AreEqual(expectedTurnover, actualTurnover);
        }

        [Test]
        public void Test_HotelConstructorShouldInitializeListOfRooms()
        {
            int expectedRooms = 0;
            int actualRooms = this.hotel.Rooms.Count;

            Assert.AreEqual(expectedRooms, actualRooms);
        }

        [Test]
        public void Test_HotelConstructorShouldInitializeListOfBookings()
        {
            int expectedBooking = 0;
            int actualBooking = this.hotel.Bookings.Count;

            Assert.AreEqual(expectedBooking, actualBooking);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("   ")]
        public void Test_HotelFullNamePropertyShouldThrowExceptionIfValueIsNullOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(name, 5));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(6)]
        [TestCase(10)]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        public void Test_HotelCategoryPropertyShouldThrowExceptionIfValueIsBelowOneOrMoreThanFive(int category)
        {
            Assert.Throws<ArgumentException>(() => new Hotel("Name", category));
        }

        [Test]
        public void Test_HotelRoomsPropertyShouldRetunIReadOnlyCollectionOfRooms()
        {
            Room room1 = new Room(2, 100);
            Room room2 = new Room(1, 120);
            Room room3 = new Room(3, 180);

            this.hotel.AddRoom(room1);
            this.hotel.AddRoom(room2);
            this.hotel.AddRoom(room3);

            IReadOnlyCollection<Room> expectedCollection = new List<Room> { room1, room2, room3 };
            IReadOnlyCollection<Room> actualCollection = this.hotel.Rooms;

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void Test_HotelBookingsPropertyShouldRetunIReadOnlyCollectionOfBookings()
        {
            Room room1 = new Room(1, 100);
            Booking booking1 = new Booking(1, room1, 1);

            this.hotel.AddRoom(room1);
            this.hotel.BookRoom(1, 0, 1, 1000);

            IReadOnlyCollection<Booking> expectedCollection = new List<Booking> { booking1 };
            IReadOnlyCollection<Booking> actualCollection = this.hotel.Bookings;

            Assert.AreEqual(expectedCollection.Count, actualCollection.Count);
            //CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void Test_HotelBookRoomMethodShouldThrowExceptionIfAdultsAreLessOrEqualToZero(int adults)
        {
            Assert.Throws<ArgumentException>(() => this.hotel.BookRoom(adults, 2, 2, 1000));
        }

        [TestCase(-26342)]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void Test_HotelBookRoomMethodShouldThrowExceptionIfChildrensIsNegative(int childrens)
        {
            Assert.Throws<ArgumentException>(() => this.hotel.BookRoom(1, childrens, 2, 1000));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void Test_HotelBookRoomMethodShouldThrowExceptionIfResidenceDurationIsLessThanOne(int residenceDuration)
        {
            Assert.Throws<ArgumentException>(() => this.hotel.BookRoom(1, 2, residenceDuration, 1000));
        }

        [Test]
        public void Test_HotelBookRoomMethodShouldReturnNoBookingIFNotEnoughBeds()
        {
            Room room = new Room(3, 53);
            this.hotel.AddRoom(room);
            this.hotel.BookRoom(4, 1, 2, 200);

            int expectedBookings = 0;
            int actualBookings = this.hotel.Bookings.Count;

            Assert.AreEqual(expectedBookings, actualBookings);
        }

        [Test]
        public void Test_HotelBookRoomMethodShouldAddTurnover()
        {
            Room room = new Room(5, 53);
            this.hotel.AddRoom(room);

            this.hotel.BookRoom(4, 1, 2, 106);
            
            double expectedTurnover = 106;
            double actualTurnover = this.hotel.Turnover;

            Assert.AreEqual(expectedTurnover, hotel.Turnover);
        }



        [Test]
        public void Test_HotelBookRoomMethodShouldReturnNoBookingIFNotEnoughBudget()
        {
            Room room = new Room(5, 53);
            this.hotel.AddRoom(room);
            this.hotel.BookRoom(4, 1, 2, 100);

            int expectedBookings = 0;
            int actualBookings = this.hotel.Bookings.Count;

            Assert.AreEqual(expectedBookings, actualBookings);
        }
    }
}