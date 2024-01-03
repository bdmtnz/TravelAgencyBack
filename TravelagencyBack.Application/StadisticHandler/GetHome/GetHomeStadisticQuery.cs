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
    public class GetHomeStadisticQuery : IRequestHandler<GetHomeStadisticRequest, ApiResponse<List<GetHomeStadisticResponse>>>
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

        public Task<ApiResponse<List<GetHomeStadisticResponse>>> Handle(GetHomeStadisticRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<List<GetHomeStadisticResponse>> response;
            var Hotels = new GetHomeStadisticHotel()
            {
                N_creados = _hotelRepository.Count(),
                Habilitados = _hotelRepository.FindBy(hotel => hotel.Enabled).Count()
            };
            var Rooms = new GetHomeStadisticRoom()
            {
                N_creados = _roomRepository.Count(),
                Disponibles = _roomRepository.FindBy(room => room.CanBookingOverAll(DateTime.Now, DateTime.Now.AddDays(1))).Count()
            };
            var Bookings = new GetHomeStadisticBooking()
            {
                N_creados = _bookingRepository.Count(),
                Habilitados = _bookingRepository.FindBy(booking => booking.Enabled).Count()
            };

            var stadistics = new List<GetHomeStadisticResponse>()
            {
                new GetHomeStadisticResponse()
                {
                    Title = "Hoteles",
                    Items = new List<GetHomeStadisticItem> {
                        new GetHomeStadisticItem() {
                            Icon = "bed",
                            Label = "Registrados",
                            Value = Hotels.N_creados
                        },
                        new GetHomeStadisticItem() {
                            Icon = "lock_open",
                            Label = "Habilitados",
                            Value = Hotels.Habilitados
                        },
                        new GetHomeStadisticItem() {
                            Icon = "lock",
                            Label = "Deshabilitados",
                            Value = Hotels.Deshabilitados
                        }
                    }
                },
                new GetHomeStadisticResponse()
                {
                    Title = "Habitaciones",
                    Items = new List<GetHomeStadisticItem> {
                        new GetHomeStadisticItem() {
                            Icon = "door_open",
                            Label = "Registradas",
                            Value = Rooms.N_creados
                        },
                        new GetHomeStadisticItem() {
                            Icon = "check",
                            Label = "Disponibles",
                            Value = Rooms.Disponibles
                        },
                        new GetHomeStadisticItem() {
                            Icon = "luggage",
                            Label = "Reservadas",
                            Value = Rooms.Reservadas
                        }
                    }
                },
                new GetHomeStadisticResponse()
                {
                    Title = "Reservaciones",
                    Items = new List<GetHomeStadisticItem> {
                        new GetHomeStadisticItem() {
                            Icon = "door_open",
                            Label = "Registradas",
                            Value = Bookings.N_creados
                        },
                        new GetHomeStadisticItem() {
                            Icon = "lock_open",
                            Label = "Habilitadas",
                            Value = Bookings.Habilitados
                        }
                    }
                }
            };
            response = new ApiResponse<List<GetHomeStadisticResponse>>()
            {
                Status = System.Net.HttpStatusCode.OK,
                Message = Resources.OkResponseES.SUCCESSFUL_PROCCESS,
                Data = stadistics
            };
            return Task.FromResult(response);
        }
    }
}
