using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;

namespace TravelAgencyBack.Application.RoomHandler.GetById
{
    public class GetRoomByIdRequest : IRequest<ApiResponse<Room>>
    {
        [Required]
        public string Id { get; set; }

        public GetRoomByIdRequest(string id)
        {
            Id = id;
        }
    }
}
