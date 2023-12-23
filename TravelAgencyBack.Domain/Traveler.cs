using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.ValueObjects;

namespace TravelAgencyBack.Domain
{
    public class Traveler : Person
    {
        public Credential Credential { get; set; }
        public List<Booking> Bookings { get; set; }

        public Traveler()
        {
            
        }

        public Traveler(string name, string lastName, DateTime birth, Phone phone, Document document, Gender gender, string email, Credential credential) : base()
        {
            Name = name;
            Birth = birth;
            Gender = gender;
            Phone = phone;
            Document = document;
            Email = email;
            LastName = lastName;
            Credential = credential;
            Bookings = new List<Booking>();
        }

        public void AddBooking(Booking booking)
        {
            Bookings.Add(booking);
        }
    }
}
