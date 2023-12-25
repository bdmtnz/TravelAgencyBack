using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain;

namespace TravelHotelBack.Infrastructure.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> HotelConfiguration)
        {

            //Address value object persisted as owned entity in EF Core 2.0
            //HotelConfiguration.OwnsOne(o => o.Credential);
            HotelConfiguration.Navigation(hotel => hotel.Rooms).AutoInclude();

            //contactConfiguration.Property<DateTime>("OrderDate").IsRequired();

            //...Additional validations, constraints and code...
            //...
        }
    }
}
