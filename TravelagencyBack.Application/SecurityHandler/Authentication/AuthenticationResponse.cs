using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelagencyBack.Application.Base;
using TravelAgencyBack.Domain.Base;

namespace TravelagencyBack.Application.Security.Authentication
{
    public class AuthenticationResponse
    {
        public string Name { get; set; }
        public EnumResponse<Rol> Rol { get; set; }
        public string Token { get; set; }
    }
}
