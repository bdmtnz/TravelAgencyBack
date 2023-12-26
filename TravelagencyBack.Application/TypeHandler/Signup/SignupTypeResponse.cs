using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.ValueObjects;

namespace TravelAgencyBack.Application.TypeHandler.Signup
{
    public class SignupTypeResponse
    {
        public IEnumerable<EnumResponse<Gender>> Genders { get; set; }
        public IEnumerable<EnumResponse<DocumentType>> DocumentTypes { get; set; }

    }
}
