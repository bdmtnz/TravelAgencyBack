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

    public class Contact : Entity
    {
        public string Name { get; private set; }
        public Phone Phone { get; private set; }

        public Contact() {  }

        public Contact(string name, Phone phone)
        {
            Name = name;
            Phone = phone;
        }
    }

    public class Person : Contact
    {
        public string LastName { get; private set; }
        public DateTime Birth { get; private set; }
        public Gender Gender { get; private set; }
        public Document Document { get; private set; }
        public string Email { get; private set; }

        public Person()
        {

        }

        public Person(string lastName, DateTime birth, Gender gender, Document document, string email)
        {
            LastName = lastName;
            Birth = birth;
            Gender = gender;
            Document = document;
            Email = email;
        }
    }
}
