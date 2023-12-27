using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Application.RoomHandler.GetById
{
    public class GetRoomByIdQuery : IRequestHandler<GetRoomByIdRequest, ApiResponse<Room>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Room> _hotelRepository;

        public GetRoomByIdQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _hotelRepository = unitOfWork.GenericRepository<Room>();
        }

        public Task<ApiResponse<Room>> Handle(GetRoomByIdRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<Room> response;
            Room? hotel;

            hotel = _hotelRepository.Find(request.Id);

            if(hotel is null)
            {
                response = new ApiResponse<Room>()
                {
                    Status = System.Net.HttpStatusCode.NotFound,
                    Message = Resources.ErrorResponsesES.NOT_FOUND,
                    Data = default
                };
                return Task.FromResult(response);
            }

            response = new ApiResponse<Room>()
            {
                Status = System.Net.HttpStatusCode.OK,
                Message = Resources.OkResponseES.SUCCESSFUL_PROCCESS,
                Data = hotel
            };
            return Task.FromResult(response);
        }
    }
}
