using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Application.HotelHandler.GetById
{
    public class GetHotelByIdQuery : IRequestHandler<GetHotelByIdRequest, ApiResponse<Hotel>>
    {{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Hotel> _hotelRepository;

        public GetHotelByIdQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _hotelRepository = unitOfWork.GenericRepository<Hotel>();
        }

        public Task<ApiResponse<Hotel>> Handle(GetHotelByIdRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<Hotel> response;
            Hotel? hotel;

            hotel = _hotelRepository.Find(request.Id);

            if(hotel is null)
            {
                response = new ApiResponse<Hotel>()
                {
                    Status = System.Net.HttpStatusCode.NotFound,
                    Message = Resources.ErrorResponsesES.NOT_FOUND,
                    Data = default
                };
                return Task.FromResult(response);
            }

            response = new ApiResponse<Hotel>()
            {
                Status = System.Net.HttpStatusCode.OK,
                Message = Resources.OkResponseES.SUCCESSFUL_PROCCESS,
                Data = hotel
            };
            return Task.FromResult(response);
        }
    }
}
