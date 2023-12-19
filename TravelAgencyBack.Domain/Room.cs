using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;

namespace TravelAgencyBack.Domain
{
    public enum RoomType
    {
        A,
        B,
        C
    }

    public class Room : Entity
    {
        public string Location { get; set; }
        public RoomType Type { get; set; }
        public double Cost { get; set; }
        public double Tax { get; set; }
        public int Capacity { get; set; }
        public List<Booking> Bookings { get; set; }

        public Room()
        {
            Type = RoomType.A;
            Location = string.Empty;
            Bookings = new List<Booking>();
        }
    }
}
