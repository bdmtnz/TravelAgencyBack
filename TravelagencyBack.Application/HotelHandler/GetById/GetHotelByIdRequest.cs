using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;

namespace TravelAgencyBack.Application.HotelHandler.GetById
{
    public class GetHotelByIdRequest : IRequest<ApiResponse<Hotel>>
    {
        [Required]
        public string Id { get; set; }

        public GetHotelByIdRequest(string id)
        {
            Id = id;
        }
    }
}
