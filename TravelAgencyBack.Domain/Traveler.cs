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
    }
}
