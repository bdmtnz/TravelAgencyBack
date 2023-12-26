using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;

namespace TravelAgencyBack.Application.RoomHandler.Free
{
    public class FreeRoomRequest : IRequest<ApiResponse<IEnumerable<Room>>>
    {
        public int QuantityPeople { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string City { get; set; }
    }
}
