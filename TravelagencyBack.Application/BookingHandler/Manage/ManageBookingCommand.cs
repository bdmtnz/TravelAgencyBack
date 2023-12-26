using MediatR;
using System.Net;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.Contracts;
using TravelAgencyBack.Domain.ValueObjects;

namespace TravelAgencyBack.Application.BookingHandler.Manage
{
    public class ManageBookingCommand : IRequestHandler<ManageBookingRequest, ApiResponse<object>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Hotel> _hotelRepository;
        private readonly IGenericRepository<Traveler> _travelerRepository;
        private readonly IGenericRepository<Room> _roomRepository;
        //private readonly IGenericRepository<Contact> _contactRepository;
        private readonly IGenericRepository<Booking> _bookingRepository;

        public ManageBookingCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _travelerRepository = _unitOfWork.GenericRepository<Traveler>();
            _bookingRepository = unitOfWork.GenericRepository<Booking>();
            _roomRepository = unitOfWork.GenericRepository<Room>();
            _hotelRepository = unitOfWork.GenericRepository<Hotel>();
        }

        public Task<ApiResponse<object>> Handle(ManageBookingRequest request, CancellationToken cancellationToken)
        {
            ApiResponse<object> response;
            if (_bookingRepository is null)
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
            var travelers = _travelerRepository.GetAll();
            var traveler = _travelerRepository.FindBy(traveler => traveler.Credential.Id == request.CredentialId).FirstOrDefault();
            if (traveler is null)
            {
                response = new ApiResponse<object>()
                {
                    Data = default,
                    Message = Resources.ErrorResponsesES.NOT_FOUND,
                    Status = HttpStatusCode.NotFound
                };
                return Task.FromResult(response);
            }

            var room = _roomRepository.Find(request.RoomId);
            if (room is null)
            {
                response = new ApiResponse<object>()
                {
                    Data = default,
                    Message = Resources.ErrorResponsesES.NOT_FOUND,
                    Status = HttpStatusCode.NotFound
                };
                return Task.FromResult(response);
            }

            var hotel = room.Hotel;

            List<Person> guests = request.Guests.Select(guestReq =>
            {
                var document = new Document(guestReq.DocumentType, guestReq.Document);
                var phone = new Phone(guestReq.Indicative, guestReq.Phone);
                return new Person(guestReq.Name, guestReq.LastName, guestReq.Birth, guestReq.Gender, document, guestReq.Email, phone);
            }).ToList();

            var phone = new Phone(request.EmergencyContact.Indicative, request.EmergencyContact.Phone);
            Contact emergencyContact = new Contact(request.EmergencyContact.Name, phone);

            var domainResponse = hotel.AddBooking(room, traveler, guests, emergencyContact, request.Start, request.End, request.City);
            if(domainResponse.HaveError)
            {
                response = new ApiResponse<object>()
                {
                    Data = default,
                    Message = domainResponse.Message,
                    Status = HttpStatusCode.BadRequest
                };
                _unitOfWork.Rollback();
            }
            else
            {
                _hotelRepository.Update(hotel);
                _roomRepository.Update(room);
                _travelerRepository.Update(traveler);
                _unitOfWork.Commit();
                response = new ApiResponse<object>()
                {
                    Status = System.Net.HttpStatusCode.OK,
                    Message = string.Format(Resources.OkResponseES.RESOURCE_CREATED_BY, new object[] { "Reserva", domainResponse.Data.Id, "Viajero", traveler.Id }),
                    Data = default
                };
            }
            return Task.FromResult(response);
        }
    }
}
