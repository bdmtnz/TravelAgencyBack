using Microsoft.EntityFrameworkCore;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.ValueObjects;

namespace TravelAgencyBack.Infrastructure
{
    public class TravelAgencyContext : DbContext
    {
        public TravelAgencyContext(DbContextOptions<TravelAgencyContext> options)
            : base(options)
        { }

        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Phone<Contact>> Phones { get; set; }
        public DbSet<Document<Person>> Documents { get; set; }
        public DbSet<Credential<Traveler>> Credentials { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Traveler> Travelers { get; set; }
    }
}
