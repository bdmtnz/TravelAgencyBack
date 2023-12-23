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
        public string Name { get; set; }
        public string LastName { get; set; }
        public Phone Phone { get; set; }

        public Contact() {  }

        public Contact(string name, string lastName, Phone phone)
        {
            Name = name;
            LastName = lastName;
            Phone = phone;
        }
    }

    public class Person : Contact
    {
        public DateTime Birth { get; set; }
        public Gender Gender { get; set; }
        public Document Document { get; set; }
        public string Email { get; set; }

        public Person()
        {

        }
        public Person(DateTime birth, Gender gender, Document document, string email)
        {
            Birth = birth;
            Gender = gender;
            Document = document;
            Email = email;
        }
    }
}
