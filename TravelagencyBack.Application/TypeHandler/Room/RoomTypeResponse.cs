using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Base;

namespace TravelAgencyBack.Application.TypeHandler.Room
{
    public class RoomTypeResponse
    {
        public IEnumerable<EnumResponse<RoomType>> Types { get; set; }
    }
}
