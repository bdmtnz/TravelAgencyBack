using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Application.Hotelhandler.Filter
{
    public class FilterHotelQuery : IRequestHandler<FilterHotelRequest, ApiResponse<IEnumerable<Hotel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Hotel> _hotelRepository;

        public FilterHotelQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _hotelRepository = unitOfWork.GenericRepository<Hotel>();
        }

        public Task<ApiResponse<IEnumerable<Hotel>>> Handle(FilterHotelRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<IEnumerable<Hotel>> response;
            IEnumerable<Hotel> hotels;

            Func<Hotel, bool> filter = (hotel) =>
            {
                return
                    string.IsNullOrEmpty(request.Name)  ? true : hotel.Name.ToLower().Contains(request.Name.ToLower()) &&
                    request.Enabled is null             ? true : hotel.Enabled == request.Enabled;
            };

            hotels = _hotelRepository.FindBy(filter);

            response = new ApiResponse<IEnumerable<Hotel>>()
            {
                Status = System.Net.HttpStatusCode.OK,
                Message = Resources.OkResponseES.SUCCESSFUL_PROCCESS,
                Data = hotels
            };
            return Task.FromResult(response);
        }
    }
}
