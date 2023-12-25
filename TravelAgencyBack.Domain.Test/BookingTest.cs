using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.ValueObjects;

namespace TravelAgencyBack.Domain.Test
{
    public class BookingTest
    {
        private Booking Booking;

        [SetUp]
        public void Setup()
        {
            var hotel = new Hotel("Hotel prueba", "Descripción hotel prueba", "https://algo.com/img.png");
            var room = hotel.AddRoom("202A", RoomType.Matrimonial, 20000, 10, 30, 2, "Medallo", "https://algo.com/img.png");
            var phone = new Phone(57, "3116390221");
            var document = new Document(DocumentType.CC, "1065852002");
            var email = "martinez_o@hotmail.es";
            var traveler = new Traveler("Luis", "Alfonso", DateTime.Now.AddYears(-20), phone, document, Gender.Male, email, "");
            var guests = new List<Person> {
                new Person("David", "Lopez", DateTime.Now.AddYears(-18), Gender.Male, document, email, phone)
            };
            var contact = new Contact("Lorena", phone);
            var disabledBooking = room.AddBooking(traveler, guests, contact, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-8), "Medallo");
            if (!disabledBooking.HaveError)
            {
                Booking = disabledBooking.Data;
                Booking.SetEnable(false);
            }
        }

        [Test]
        public void ValidatePrice()
        {
            var price = Booking.Price;
            var roomPrice = Booking.Room.Price;
            var correctValue = roomPrice * 2;
            Assert.IsTrue(price == correctValue, string.Format("The price should to be equal than {0}", new object[] { correctValue }));
        }
    }
}
