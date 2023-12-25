using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TravelagencyBack.Application.Base;
using TravelagencyBack.Application.Security.Authentication;
using TravelAgencyBack.Domain.Contracts;

namespace TravelagencyBack.Application.Hotelhandler.Add
{
    public class ManageHotelCommand : IRequestHandler<ManageHotelRequest, ApiResponse<object>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TravelAgencyBack.Domain.Hotel> _hotelRepository;
        public ManageHotelCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _hotelRepository = unitOfWork.GenericRepository<TravelAgencyBack.Domain.Hotel>();
        }
        public Task<ApiResponse<object>> Handle(ManageHotelRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<object> response;
            if(_hotelRepository is null)
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

            TravelAgencyBack.Domain.Hotel? hotel;
            var message = "";
            if (string.IsNullOrEmpty(request.Id))
            {
                hotel = new TravelAgencyBack.Domain.Hotel(request.Name, request.Description, request.ImageUrl);
                _hotelRepository.Add(hotel);
                message = Resources.OkResponseES.RESOURCE_CREATED;
            }
            else
            {
                hotel = _hotelRepository.Find(request.Id);
                if(hotel is null)
                {
                    response = new ApiResponse<object>()
                    {
                        Data = default,
                        Message = Resources.ErrorResponsesES.NOT_FOUND,
                        Status = HttpStatusCode.NotFound
                    };
                    return Task.FromResult(response);
                }

                hotel.Update(request.Name, request.Description, request.ImageUrl);
                _hotelRepository.Update(hotel);
                message = Resources.OkResponseES.RESOURCE_MODIFIED;
            }

            _unitOfWork.Commit();
            response = new ApiResponse<object>()
            {
                Status = System.Net.HttpStatusCode.OK,
                Message = string.Format(message, new object[] { hotel.Id }),
                Data = default
            };
            return Task.FromResult(response);
        }
    }
}
