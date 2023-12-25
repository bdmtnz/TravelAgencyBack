using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TravelagencyBack.Application.Base;
using TravelagencyBack.Application.Security.Authentication;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Contracts;

namespace TravelagencyBack.Application.RoomHandler.Add
{
    public class ManageRoomCommand : IRequestHandler<ManageRoomRequest, ApiResponse<object>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Hotel> _hotelRepository;
        private readonly IGenericRepository<Room> _roomRepository;

        public ManageRoomCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _roomRepository = unitOfWork.GenericRepository<Room>();
            _hotelRepository = unitOfWork.GenericRepository<Hotel>();
        }

        public Task<ApiResponse<object>> Handle(ManageRoomRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<object> response;
            if (_roomRepository is null)
            {
                response = new ApiResponse<object>()
                {
                    Data = default,
                    Message = Resources.ErrorResponsesES.INTERNAL_SERVER_ERROR,
                    Status = HttpStatusCode.InternalServerError
                };
                return Task.FromResult(response);
            }

            if (request is null)
            {
                response = new ApiResponse<object>()
                {
                    Status = System.Net.HttpStatusCode.BadRequest,
                    Message = Resources.ErrorResponsesES.BAD_REQUEST,
                    Data = default
                };
                return Task.FromResult(response);
            }

            var hotel = _hotelRepository.Find(request.HotelId);

            if (hotel is null)
            {
                response = new ApiResponse<object>()
                {
                    Data = default,
                    Message = Resources.ErrorResponsesES.NOT_FOUND,
                    Status = HttpStatusCode.NotFound
                };
                return Task.FromResult(response);
            }

            Room? room;
            var message = "";
            if (string.IsNullOrEmpty(request.Id))
            {
                room = hotel.AddRoom(
                    request.Location, 
                    request.Type, 
                    request.Cost, 
                    request.Tax, 
                    request.Profit, 
                    request.Capacity, 
                    request.City,
                    request.ImageUrl
                );
                //_roomRepository.Add(room);
                //_unitOfWork.Commit();
                _hotelRepository.Update(hotel);
                _unitOfWork.Commit();
                message = Resources.OkResponseES.RESOURCE_CREATED;
            }
            else
            {
                room = _roomRepository.Find(request.Id);
                if(room is null)
                {
                    response = new ApiResponse<object>()
                    {
                        Data = default,
                        Message = Resources.ErrorResponsesES.NOT_FOUND,
                        Status = HttpStatusCode.NotFound
                    };
                    return Task.FromResult(response);
                }

                room.Update(request.Location, request.Type, request.Cost, request.Tax, request.Profit, request.Capacity, request.City);
                _roomRepository.Update(room);
                _unitOfWork.Commit();
                message = Resources.OkResponseES.RESOURCE_MODIFIED;
            }

            _unitOfWork.Commit();
            response = new ApiResponse<object>()
            {
                Status = System.Net.HttpStatusCode.OK,
                Message = string.Format(message, new object[] { room.Id }),
                Data = default
            };
            return Task.FromResult(response);
        }
    }
}
