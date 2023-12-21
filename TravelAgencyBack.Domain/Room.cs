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
        public double Profit { get; set; }
        public int Capacity { get; set; }
        public double Price => GetPrice();
        public List<Booking> Bookings { get; set; }

        public Room(string location, RoomType type, double cost, double tax, double profit, int capacity) : base()
        {
            Location = location;
            Type = type;
            Cost = cost;
            Tax = tax;
            Profit = profit;
            Capacity = capacity;
            Bookings = new List<Booking>();
        }

        private double GetPrice()
        {
            var taxxes = Cost * (Tax / 100);
            var profit = Cost * (Profit / 100);
            return Cost + taxxes + profit;
        }

        public Booking AddBooking(Traveler traveler, List<Person> guests, Contact emergencyContact, DateTime start, DateTime end)
        {
            var booking = new Booking(this, traveler, guests, emergencyContact, start, end);
            Bookings.Add(booking);
            return booking;
        }

        public bool CanBooking(int quantitypeople, DateTime start, DateTime end)
        {
            if(quantitypeople > Capacity) return false;
            var bookings = Bookings.Where(booking => booking.Start <= end && booking.End >= start);
            return !bookings.Any();
        }
    }
}
