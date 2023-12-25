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
    public class TravelerConfiguration : IEntityTypeConfiguration<Traveler>
    {
        public void Configure(EntityTypeBuilder<Traveler> travelerConfiguration)
        {

            //Address value object persisted as owned entity in EF Core 2.0
            //travelerConfiguration.OwnsOne(o => o.Credential);
            travelerConfiguration.Navigation(traveler => traveler.Credential).AutoInclude();
            travelerConfiguration.Navigation(traveler => traveler.Bookings).AutoInclude();
            travelerConfiguration.OwnsOne(o => o.Document);

            //contactConfiguration.Property<DateTime>("OrderDate").IsRequired();

            //...Additional validations, constraints and code...
            //...
        }
    }
}
