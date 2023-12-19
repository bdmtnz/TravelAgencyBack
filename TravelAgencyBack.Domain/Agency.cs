using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.ValueObjects;

namespace TravelAgencyBack.Domain
{
    public class Agency : Entity
    {
        public string Name { get; set; }
        public Credential Credential { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<Person> Clients { get; set; }

        public Agency()
        {
            Name = string.Empty;
            Credential = new Credential();
        }
    }
}
