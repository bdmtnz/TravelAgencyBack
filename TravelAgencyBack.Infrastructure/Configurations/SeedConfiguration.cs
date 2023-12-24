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
    public class SeedConfiguration : IEntityTypeConfiguration<Credential>
    { 
        public void Configure(EntityTypeBuilder<Credential> CredentialConfiguration)
        {
            //Address value object persisted as owned entity in EF Core 2.0


            //CredentialConfiguration.Property<DateTime>("OrderDate").IsRequired();

            //...Additional validations, constraints and code...
            //...
        }
    }
}
