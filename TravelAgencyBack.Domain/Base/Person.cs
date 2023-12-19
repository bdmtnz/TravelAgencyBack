using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.ValueObjects;

namespace TravelAgencyBack.Domain.Base
{
    public enum Gender
    {
        Female,
        Male,
        Other
    }

    public abstract class Contact : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Phone Phone { get; set; }
    }

    public abstract class Person : Contact
    {
        public DateTime Birth { get; set; }
        public Gender Gender { get; set; }
        public Document Document { get; set; }
        public string Email { get; set; }
    }
}
