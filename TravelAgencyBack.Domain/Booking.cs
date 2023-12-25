using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.ValueObjects;

namespace TravelAgencyBack.Domain
{
    public class Booking : Entity
    {
        public Room Room { get; private set; }
        public Traveler Traveler { get; private set; }
        public List<Person> Guests { get; private set; }
        public Contact EmergencyContact { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public int QuantityPeople => Guests.Count + 1;
        public double Price => GetPrice();

        public Booking()
        {
            
        }

        internal Booking(Room room, Traveler traveler, List<Person> guests, Contact emergencyContact, DateTime start, DateTime end) : base()
        {
            Room = room;
            Traveler = traveler;
            Guests = guests;
            EmergencyContact = emergencyContact;
            Start = start;
            End = end;
        }

        private double GetPrice()
        {
            var days = (End - Start).Days;
            return days * Room.Price;
        }
    }
}
