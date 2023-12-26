using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Application.RoomHandler.Free
{
    public class FreeRoomQuery : IRequestHandler<FreeRoomRequest, ApiResponse<IEnumerable<Room>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Room> _roomRepository;

        public FreeRoomQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _roomRepository = unitOfWork.GenericRepository<Room>();
        }

        public Task<ApiResponse<IEnumerable<Room>>> Handle(FreeRoomRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<IEnumerable<Room>> response;
            IEnumerable<Room> rooms;

            Func<Room, bool> filter = (room) =>
            {
                return
                    //string.IsNullOrEmpty(request.Hotel)    ? true : room.Hotel.Name.ToLower().Contains(request.Hotel) &&
                    room.CanBooking(request.QuantityPeople, request.Start, request.End, request.City);
            };

            rooms = _roomRepository.FindBy(filter);

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
