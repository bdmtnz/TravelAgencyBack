using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelagencyBack.Application.Base;
using TravelAgencyBack.Domain;

namespace TravelagencyBack.Application.RoomHandler.Filter
{
    public class FilterRoomRequest : IRequest<ApiResponse<IEnumerable<Room>>>
    {
        public string? Hotel { get; set; }
        public string? Location { get; set; }
        public RoomType? Type { get; set; }
        public int? Capacity { get; set; }
        public string? City { get; set; }
        public bool? Enabled { get; set; }
    }
}
