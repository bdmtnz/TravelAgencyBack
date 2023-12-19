using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyBack.Domain.ValueObjects
{
    public class Credential
    {
        public string User { get; set; }
        public string Password { get; set; }

        public Credential()
        {
            User = string.Empty;
            Password = string.Empty;
        }
    }
}
