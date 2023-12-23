using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelagencyBack.Application.Security.Authentication
{
    public class AuthenticationResponse
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}
