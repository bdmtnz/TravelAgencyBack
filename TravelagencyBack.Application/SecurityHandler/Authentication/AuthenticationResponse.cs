using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain.Base;

namespace TravelAgencyBack.Application.Security.Authentication
{
    public class AuthenticationResponse
    {
        public string Name { get; set; }
        public EnumResponse<Rol> Rol { get; set; }
        public string Token { get; set; }
    }
}
