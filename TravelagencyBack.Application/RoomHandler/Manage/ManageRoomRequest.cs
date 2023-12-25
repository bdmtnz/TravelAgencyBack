using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;

namespace TravelAgencyBack.Application.RoomHandler.Add
{
    public class ManageRoomRequest : IRequest<ApiResponse<object>>
    {
        public string? Id { get; set; }
        [Required]
        public string HotelId { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public RoomType Type { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public double Tax { get; set; }
        [Required]
        public double Profit { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
