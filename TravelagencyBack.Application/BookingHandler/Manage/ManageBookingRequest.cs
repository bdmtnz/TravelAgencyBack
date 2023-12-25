using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.ValueObjects;

namespace TravelAgencyBack.Application.BookingHandler.Manage
{
    public class ManageBookingRequest : IRequest<ApiResponse<object>>
    {
        public string RoomId { get; set; }
        public string TravelerId { get; set; }
        public List<BookingPersonRequest> Guests { get; set; }
        public BookingContactRequest EmergencyContact { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string City { get; set; }
    }

    public class BookingContactRequest
    {
        public string Name { get; set; }
        public int Indicative { get; set; }
        public string Phone { get; set; }
    }

    public class BookingPersonRequest : BookingContactRequest
    {
        public DocumentType DocumentType { get; set; }
        public string Document { get; set; }
        public string LastName { get; private set; }
        public DateTime Birth { get; private set; }
        public Gender Gender { get; private set; }
        public string Email { get; private set; }
    }
}
