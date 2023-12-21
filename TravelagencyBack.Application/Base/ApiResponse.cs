using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;

namespace TravelagencyBack.Application.Base
{
    public class ApiResponse<T> : Response<T>
    {
        public int Status { get; set; }
    }
}
