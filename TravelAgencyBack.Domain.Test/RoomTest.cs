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
                    Birth = new DateTime().AddYears(-18),
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
            Assert.IsFalse(canBooking, "Don´t can create a booking with this dates");
        }
    }
}