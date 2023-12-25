using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TravelagencyBack.Application.Base;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Contracts;

namespace TravelagencyBack.Application.Switch
{
    public class SwitchHotelCommand : IRequestHandler<SwitchHotelRequest, ApiResponse<object>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Hotel> _hotelRepository;

        public SwitchHotelCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _hotelRepository = unitOfWork.GenericRepository<Hotel>();
        }

        public Task<ApiResponse<object>> Handle(SwitchHotelRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<object> response;
            if (_hotelRepository is null)
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

            var hotel = _hotelRepository.Find(request.Id);
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

            hotel.SetEnable(request.Enabled);
            _hotelRepository.Update(hotel);
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
