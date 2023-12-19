using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;

namespace TravelAgencyBack.Domain
{
    public class Booking : Entity
    {
        public Room Room { get; set; }
        public Traveler Traveler { get; set; }
        public List<Person> Guests { get; set; }
        public Contact EmergencyContact { get; set; }
        public int QuantityPeople => Guests.Count + 1;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Booking()
        {
            Room = new Room();
            Traveler = new Traveler();
            Guests = new List<Person>();
        }
    }
}
