using System;
using System.Collections;
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
            var type = TValue.GetType();
            var values = Enum.GetValues(type);
            var valuesParsed = values.OfType<KeyValuePair<string, int>>().ToList();
            Name = TValue.ToString();
            var tuple = valuesParsed.FirstOrDefault(value => value.Key.ToLower() == Name.ToLower());
            Id = tuple.Value;
        }
    }
}
