using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Contracts;
using TravelAgencyBack.Domain.ValueObjects;

namespace TravelAgencyBack.Domain.Base
{
    public enum Rol
    {
        Agency,
        Traveler
    }

    public class Credential : Entity
    {
        public string User { get; private set; }
        public Rol Rol { get; private set; }
        internal string Password { get; private set; }
        public Contact Contact { get; private set; }

        public Credential()
        {

        }

        public Credential(string user, string name, string password, Rol rol, Phone phone)
        {
            User = user;
            Password = password;
            Rol = rol;
            Contact = new Contact(name, phone);
        }
    }
}
