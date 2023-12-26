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
    public class Booking : Entity
    {
        [ForeignKey("Room")]
        public string RoomId { get; private set; }
        public Room Room { get; private set; }
        public Traveler Traveler { get; private set; }
        public ICollection<Person> Guests { get; private set; }
        public Contact EmergencyContact { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public double Price { get; private set; }
        public int QuantityPeople => Guests.Count + 1;

        public Booking()
        {
            
        }

        internal Booking(Room room, Traveler traveler, ICollection<Person> guests, Contact emergencyContact, DateTime start, DateTime end) : base()
        {
            Room = room;
            Traveler = traveler;
            Guests = guests;
            EmergencyContact = emergencyContact;
            Start = start;
            End = end;
            Price = GetPrice(Room.Price);
        }

        private double GetPrice(double roomPrice)
        {
            var days = (End - Start).Days;
            return days * roomPrice;
        }
    }
}
