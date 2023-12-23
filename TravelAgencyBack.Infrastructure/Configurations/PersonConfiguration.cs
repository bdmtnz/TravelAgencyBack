using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;

namespace TravelAgencyBack.Infrastructure.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> personConfiguration)
        {

            //Address value object persisted as owned entity in EF Core 2.0
            personConfiguration.OwnsOne(o => o.Phone);
            personConfiguration.OwnsOne(o => o.Document);

            //contactConfiguration.Property<DateTime>("OrderDate").IsRequired();

            //...Additional validations, constraints and code...
            //...
        }
    }
}
