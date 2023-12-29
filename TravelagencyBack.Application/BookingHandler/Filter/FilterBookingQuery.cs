using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Application.BookingHandler.Filter
{
    public class FilterBookingQuery : IRequestHandler<FilterBookingRequest, ApiResponse<IEnumerable<Booking>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Booking> _bookingRepository;
        private readonly IGenericRepository<Room> _roomRepository;

        public FilterBookingQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _bookingRepository = unitOfWork.GenericRepository<Booking>();
            _roomRepository = unitOfWork.GenericRepository<Room>();
        }

        public Task<ApiResponse<IEnumerable<Booking>>> Handle(FilterBookingRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<IEnumerable<Booking>> response;
            IEnumerable<Booking> bookings;

            Func<Booking, bool> filter = (booking) =>
            {
                return
                    string.IsNullOrEmpty(request.HotelId) ? true : booking.Room.Hotel.Id == request.HotelId &&
                    string.IsNullOrEmpty(request.RoomId) ? true : booking.Room.Id == request.RoomId &&
                    string.IsNullOrEmpty(request.TravelerId) ? true : booking.Traveler.Id == request.TravelerId &&
                    request.Start is null ? true : (booking.Start - request.Start.Value).Days == 0 &&
                    request.End is null ? true : (booking.End - request.End.Value).Days == 0 &&
                    request.Enabled is null ? true : booking.Enabled == request.Enabled;
            };

            bookings = _bookingRepository.FindBy(filter, "Room").Select(booking =>
            {
                Room? room = _roomRepository.Find(booking.RoomId, true);
                booking.LoadRoom(room);
                return booking;
            });

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
