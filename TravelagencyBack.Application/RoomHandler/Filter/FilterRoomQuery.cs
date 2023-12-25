using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelagencyBack.Application.Base;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Contracts;

namespace TravelagencyBack.Application.RoomHandler.Filter
{
    public class FilterRoomQuery : IRequestHandler<FilterRoomRequest, ApiResponse<IEnumerable<Room>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Room> _hotelRepository;

        public FilterRoomQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _hotelRepository = unitOfWork.GenericRepository<Room>();
        }

        public Task<ApiResponse<IEnumerable<Room>>> Handle(FilterRoomRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<IEnumerable<Room>> response;
            IEnumerable<Room> rooms;

            Func<Room, bool> filter = (room) =>
            {
                return
                    //string.IsNullOrEmpty(request.Hotel)    ? true : room.Hotel.Name.ToLower().Contains(request.Hotel) &&
                    string.IsNullOrEmpty(request.City)     ? true : room.City.ToLower().Contains(request.City) &&
                    string.IsNullOrEmpty(request.Location) ? true : room.Location.ToLower().Contains(request.Location) &&
                    request.Capacity is null ? true : room.Capacity == request.Capacity &&
                    request.Type is null     ? true : room.Type == request.Type &&
                    request.Enabled is null  ? true : room.Enabled == request.Enabled;
            };

            rooms = _hotelRepository.FindBy(filter, "Hotel");

            response = new ApiResponse<IEnumerable<Room>>()
            {
                Status = System.Net.HttpStatusCode.OK,
                Message = Resources.OkResponseES.SUCCESSFUL_PROCCESS,
                Data = rooms
            };
            return Task.FromResult(response);
        }
    }
}
