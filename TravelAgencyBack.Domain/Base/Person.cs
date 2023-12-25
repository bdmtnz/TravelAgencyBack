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

    public class Person : Entity
    {
        public Contact Contact { get; protected set; }
        public string LastName { get; protected set; }
        public DateTime Birth { get; protected set; }
        public Gender Gender { get; protected set; }
        public Document Document { get; protected set; }
        public string Email { get; protected set; }

        public Person()
        {

        }

        public Person(string name, string lastName, DateTime birth, Gender gender, Document document, string email, Phone phone) : base(name, phone)
        {
            Contact = new Contact(name, phone);
            LastName = lastName;
            Birth = birth;
            Gender = gender;
            Document = document;
            Email = email;
        }
    }
}
