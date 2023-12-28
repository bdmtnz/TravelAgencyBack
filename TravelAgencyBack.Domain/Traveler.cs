using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.ValueObjects;

namespace TravelAgencyBack.Domain
{
    public class Traveler : Entity
    {
        public Person Person { get; set; }
        public Credential Credential { get; set; }
        public List<Booking> Bookings { get; set; }

        public Traveler()
        {
            
        }

        public Traveler(string name, string lastName, DateTime birth, Phone phone, Document document, Gender gender, string email, string password) : base()
        {
            Person = new Person(name, lastName, birth, gender, document, email, phone);
            Credential = new Credential(email, name, password, Rol.Traveler, phone);
            Bookings = new List<Booking>();
        }

        public void AddBooking(Booking booking)
        {
            Bookings.Add(booking);
        }
    }
}
