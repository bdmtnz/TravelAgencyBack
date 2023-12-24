using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;

namespace TravelagencyBack.Application.Base
{
    public class ApiResponse<T> : Response<T>
    {
        public HttpStatusCode Status { get; set; }
    }

    public class EnumResponse<T> where T : struct, Enum
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public EnumResponse(T TValue)
        {
            var values = Enum.GetValues(TValue.GetType());
            Id = 0;
            Name = nameof(TValue);
        }
    }
}
