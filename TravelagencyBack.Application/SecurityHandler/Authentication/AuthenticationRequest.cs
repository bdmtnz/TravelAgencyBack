using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelagencyBack.Application.Base;

namespace TravelagencyBack.Application.Security.Authentication
{
    public class AuthenticationRequest : IRequest<ApiResponse<AuthenticationResponse>>
    {
        public string User { get; set; }
        public string Password { get; set; }

        public AuthenticationRequest()
        {
            
        }

        public AuthenticationRequest(string user, string password)
        {
            User = user;
            Password = password;
        }
    }
}
