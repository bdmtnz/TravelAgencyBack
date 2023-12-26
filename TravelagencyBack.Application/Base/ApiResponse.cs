using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;

namespace TravelAgencyBack.Application.Base
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
            var values = type.GetEnumValues();
            List<string> names = new List<string>();
            for (int i = 0; i < values.Length; i++)
            {
                var obj = values.GetValue(i);
                if(obj is null) continue;
                names.Add(obj.ToString());
            }
            Name = TValue.ToString();
            Id = names.FindIndex(name => name == Name);
        }
    }
}
