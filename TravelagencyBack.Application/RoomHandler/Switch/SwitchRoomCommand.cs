using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Application.RoomHandler.Switch
{
    public class SwitchRoomCommand : IRequestHandler<SwitchRoomRequest, ApiResponse<object>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Room> _roomRepository;

        public SwitchRoomCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _roomRepository = unitOfWork.GenericRepository<Room>();
        }

        public Task<ApiResponse<object>> Handle(SwitchRoomRequest request, CancellationToken cancellationToken)
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

            var room = _roomRepository.Find(request.Id);
            if (room is null)
            {
                response = new ApiResponse<object>()
                {
                    Data = default,
                    Message = Resources.ErrorResponsesES.NOT_FOUND,
                    Status = HttpStatusCode.NotFound
                };
                return Task.FromResult(response);
            }

            room.SetEnable(request.Enabled);
            _roomRepository.Update(room);
            _unitOfWork.Commit();

            response = new ApiResponse<object>()
            {
                Status = System.Net.HttpStatusCode.OK,
                Message = Resources.OkResponseES.SUCCESSFUL_PROCCESS,
                Data = default
            };
            return Task.FromResult(response);
        }
    }
}
