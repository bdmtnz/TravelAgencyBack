using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Application.StadisticHandler.GetHome
{
    public class GetHomeStadisticQuery : IRequestHandler<GetHomeStadisticRequest, ApiResponse<GetHomeStadisticResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Hotel> _hotelRepository;
        private readonly IGenericRepository<Room> _roomRepository;
        private readonly IGenericRepository<Booking> _bookingRepository;

        public GetHomeStadisticQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _hotelRepository = unitOfWork.GenericRepository<Hotel>();
            _roomRepository = unitOfWork.GenericRepository<Room>();
            _bookingRepository = unitOfWork.GenericRepository<Booking>();
        }

        public Task<ApiResponse<GetHomeStadisticResponse>> Handle(GetHomeStadisticRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<GetHomeStadisticResponse> response;
            var stadistics = new GetHomeStadisticResponse()
            {
                Hoteles = new GetHomeStadisticHotel()
                {
                    N_creados = _hotelRepository.Count(),
                    Habilitados = _hotelRepository.FindBy(hotel => hotel.Enabled).Count()
                },
                Room = new GetHomeStadisticRoom()
                {
                    N_creados = _roomRepository.Count(),
                    Disponibles = _roomRepository.FindBy(room => room.CanBookingOverAll(DateTime.Now, DateTime.Now.AddDays(1))).Count()
                },
                Reservaciones = new GetHomeStadisticBooking()
                {
                    N_creados = _bookingRepository.Count(),
                    Habilitados = _bookingRepository.FindBy(booking => booking.Enabled).Count()
                }
            };
            response = new ApiResponse<GetHomeStadisticResponse>()
            {
                Status = System.Net.HttpStatusCode.OK,
                Message = Resources.OkResponseES.SUCCESSFUL_PROCCESS,
                Data = stadistics
            };
            return Task.FromResult(response);
        }
    }
}
