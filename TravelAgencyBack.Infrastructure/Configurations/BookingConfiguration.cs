using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Base;

namespace TravelAgencyBack.Infrastructure.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    { 
        public void Configure(EntityTypeBuilder<Booking> BookingConfiguration)
        {
            //Address value object persisted as owned entity in EF Core 2.0
            BookingConfiguration.Navigation(booking => booking.Room).AutoInclude();
            BookingConfiguration.Navigation(booking => booking.EmergencyContact).AutoInclude();
            BookingConfiguration.Navigation(booking => booking.Guests).AutoInclude();
            BookingConfiguration.Navigation(booking => booking.Traveler).AutoInclude();

            //CredentialConfiguration.Property<DateTime>("OrderDate").IsRequired();

            //...Additional validations, constraints and code...
            //...
        }
    }
}
