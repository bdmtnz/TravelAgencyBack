using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelagencyBack.Application.Base;
using TravelAgencyBack.Domain.Contracts;

namespace TravelagencyBack.Application.Hotelhandler.Filter
{
    public class FilterHotelQuery : IRequestHandler<FilterHotelRequest, ApiResponse<IEnumerable<TravelAgencyBack.Domain.Hotel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TravelAgencyBack.Domain.Hotel> _hotelRepository;

        public FilterHotelQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _hotelRepository = unitOfWork.GenericRepository<TravelAgencyBack.Domain.Hotel>();
        }

        public Task<ApiResponse<IEnumerable<TravelAgencyBack.Domain.Hotel>>> Handle(FilterHotelRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<IEnumerable<TravelAgencyBack.Domain.Hotel>> response;
            IEnumerable<TravelAgencyBack.Domain.Hotel> hotels;
            if (string.IsNullOrEmpty(request.Name))
            {
                hotels = _hotelRepository.GetAll();
            }
            else
            {
                hotels = _hotelRepository.FindBy(hotel => hotel.Name.ToLower().Contains(request.Name.ToLower()));
            }

            response = new ApiResponse<IEnumerable<TravelAgencyBack.Domain.Hotel>>()
            {
                Status = System.Net.HttpStatusCode.OK,
                Message = Resources.OkResponseES.SUCCESSFUL_PROCCESS,
                Data = hotels
            };
            return Task.FromResult(response);
        }
    }
}
