using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain;

namespace TravelRoomBack.Infrastructure.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> RoomConfiguration)
        {

            //Address value object persisted as owned entity in EF Core 2.0
            //RoomConfiguration.OwnsOne(o => o.Credential);
            RoomConfiguration.Navigation(room => room.Hotel).AutoInclude();
            RoomConfiguration.Navigation(room => room.Bookings).AutoInclude();

            //contactConfiguration.Property<DateTime>("OrderDate").IsRequired();

            //...Additional validations, constraints and code...
            //...
        }
    }
}
