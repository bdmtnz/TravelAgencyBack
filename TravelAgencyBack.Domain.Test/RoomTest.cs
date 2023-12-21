using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.ValueObjects;

namespace TravelAgencyBack.Domain.Test
{
    public class Tests
    {
        private Room Room { get; set; }

        [SetUp]
        public void Setup()
        {
            Room = new Room("202A", RoomType.B, 20000, 10, 30, 2);
            var phone = new Phone(57, "3116390221");
            var document = new Document(DocumentType.CC, "1065852002");
            var email = "martinez_o@hotmail.es";
            var credential = new Credential(email, "Password");
            var traveler = new Traveler("Luis", "Alfonso", DateTime.Now.AddYears(-20), phone, document, Gender.Male, email, credential);
            var guests = new List<Person> {
                new Person()
                {
                    Gender = Gender.Male,
                    Birth = DateTime.Now.AddYears(-18),
                    Document = document,
                    Email = email,
                    LastName = "Lopez",
                    Name = "David",
                    Phone = phone
                }
            };
            var contact = new Contact("Lorena", "Mantilla", phone);
            Room.AddBooking(traveler, guests, contact, DateTime.Now.AddDays(2), DateTime.Now.AddDays(5));
            Room.AddBooking(traveler, guests, contact, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1));
        }

        [Test]
        public void FullDateMatch()
        {
            var booking = Room.Bookings.FirstOrDefault();
            var canBooking = Room.CanBooking(2, booking.Start, booking.End);
            Assert.IsFalse(canBooking, "Don�t can create a booking with this dates");
        }

        [Test]
        public void CrossDateMatchWithSameEnd()
        {
            var booking = Room.Bookings.FirstOrDefault();
            var canBooking = Room.CanBooking(2, booking.Start.AddDays(1), booking.End);
            Assert.IsFalse(canBooking, "Don�t can create a booking with this dates");
        }

        [Test]
        public void CrossDateMatchWithSameStart()
        {
            var booking = Room.Bookings.FirstOrDefault();
            var canBooking = Room.CanBooking(2, booking.Start, booking.End.AddDays(1));
            Assert.IsFalse(canBooking, "Don�t can create a booking with this dates");
        }

        [Test]
        public void CrossDateMatchInto()
        {
            var booking = Room.Bookings.FirstOrDefault();
            var canBooking = Room.CanBooking(2, booking.Start.AddDays(1), booking.End.AddDays(-1));
            Assert.IsFalse(canBooking, "Don�t can create a booking with this dates");
        }

        [Test]
        public void CrossDateMatchIntoWithSecondElement()
        {
            var booking = Room.Bookings.LastOrDefault();
            var canBooking = Room.CanBooking(2, booking.Start.AddDays(1), booking.End.AddDays(-1));
            Assert.IsFalse(canBooking, "Don�t can create a booking with this dates");
        }

        [Test]
        public void ExcedeedCapacity()
        {
            var booking = Room.Bookings.FirstOrDefault();
            var canBooking = Room.CanBooking(3, booking.Start, booking.End);
            Assert.IsFalse(canBooking, "Don�t can create a booking with excedeed places");
        }

        [Test]
        public void AvalibleButExcedeedCapacity()
        {
            var canBooking = Room.CanBooking(3, DateTime.Now.AddDays(6), DateTime.Now.AddDays(10));
            Assert.IsFalse(canBooking, "Don�t can create a booking with excedeed places");
        }

        [Test]
        public void Avalible()
        {
            var canBooking = Room.CanBooking(2, DateTime.Now.AddDays(6), DateTime.Now.AddDays(10));
            Assert.IsTrue(canBooking, "Should create a booking with this configuration");
        }

        [Test]
        public void AvalibleBetween()
        {
            var canBooking = Room.CanBooking(2, DateTime.Now, DateTime.Now.AddDays(1));
            Assert.IsTrue(canBooking, "Should create a booking with this configuration");
        }

    }
}