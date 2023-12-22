using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Domain.ValueObjects
{
    public class Credential<T> : ValueObject<T> where T : IEntity
    {
        public string User { get; set; }
        public string Password { get; set; }

        public Credential(string user, string password)
        {
            User = user;
            Password = password;
        }
    }
}
