using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Domain.ValueObjects
{
    public class Contact : IValueObject
    {
        public string Name { get; set; }
        public Phone Phone { get; set; }

        public Contact()
        {
            
        }

        public Contact(string name, Phone phone)
        {
            Name = name;
            Phone = phone;
        }
    }
}
