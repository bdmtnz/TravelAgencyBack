﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Application.RoomHandler.Filter
{
    public class FilterRoomQuery : IRequestHandler<FilterRoomRequest, ApiResponse<IEnumerable<Room>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Room> _roomRepository;

        public FilterRoomQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _roomRepository = unitOfWork.GenericRepository<Room>();
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

            rooms = _roomRepository.FindBy(filter, "Hotel");

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
