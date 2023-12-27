using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Application.BookingHandler.GetById
{
    public class GetBookingByIdQuery : IRequestHandler<GetBookingByIdRequest, ApiResponse<Booking>>
    {{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Booking> _hotelRepository;

        public GetBookingByIdQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _hotelRepository = unitOfWork.GenericRepository<Booking>();
        }

        public Task<ApiResponse<Booking>> Handle(GetBookingByIdRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<Booking> response;
            Booking? hotel;

            hotel = _hotelRepository.Find(request.Id);

            if(hotel is null)
            {
                response = new ApiResponse<Booking>()
                {
                    Status = System.Net.HttpStatusCode.NotFound,
                    Message = Resources.ErrorResponsesES.NOT_FOUND,
                    Data = default
                };
                return Task.FromResult(response);
            }

            response = new ApiResponse<Booking>()
            {
                Status = System.Net.HttpStatusCode.OK,
                Message = Resources.OkResponseES.SUCCESSFUL_PROCCESS,
                Data = hotel
            };
            return Task.FromResult(response);
        }
    }
}
