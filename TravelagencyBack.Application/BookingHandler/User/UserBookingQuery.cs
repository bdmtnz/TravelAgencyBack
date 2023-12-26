using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Application.BookingHandler.User
{
    public class UserBookingQuery : IRequestHandler<UserBookingRequest, ApiResponse<IEnumerable<Booking>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Booking> _bookingRepository;

        public UserBookingQuery(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
            _bookingRepository = unitOfWork.GenericRepository<Booking>();
        }

        public Task<ApiResponse<IEnumerable<Booking>>> Handle(UserBookingRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<IEnumerable<Booking>> response;
            IEnumerable<Booking> bookings;

            Func<Booking, bool> filter = (booking) =>
            {
                return booking.Traveler.Credential.Id == request.CredentialId;
            };

            bookings = _bookingRepository.FindBy(filter);

            response = new ApiResponse<IEnumerable<Booking>>()
            {
                Status = System.Net.HttpStatusCode.OK,
                Message = Resources.OkResponseES.SUCCESSFUL_PROCCESS,
                Data = bookings
            };
            return Task.FromResult(response);
        }
    }
}
