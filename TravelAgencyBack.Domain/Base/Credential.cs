using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Contracts;

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
        public string Password { get; private set; }

        public Credential(string user, string password, Rol rol)
        {
            User = user;
            Password = password;
            Rol = rol;
        }
    }
}
