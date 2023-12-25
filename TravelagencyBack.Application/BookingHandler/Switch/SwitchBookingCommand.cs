using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Application.Base;
using TravelAgencyBack.Application.BookingHandler.Switch;
using TravelAgencyBack.Domain.Contracts;
using TravelAgencyBack.Domain;

namespace TravelAgencyBack.Application.BookingHandler.Switch
{
    public class SwitchBookingCommand : IRequestHandler<SwitchBookingRequest, ApiResponse<object>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Booking> _bookingRepository;

        public SwitchBookingCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _bookingRepository = unitOfWork.GenericRepository<Booking>();
        }

        public Task<ApiResponse<object>> Handle(SwitchBookingRequest request, CancellationToken cancellationToken)
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

            var booking = _bookingRepository.Find(request.Id);
            if (booking is null)
            {
                response = new ApiResponse<object>()
                {
                    Data = default,
                    Message = Resources.ErrorResponsesES.NOT_FOUND,
                    Status = HttpStatusCode.NotFound
                };
                return Task.FromResult(response);
            }

            booking.SetEnable(request.Enabled);
            _bookingRepository.Update(booking);
            _unitOfWork.Commit();

            response = new ApiResponse<object>()
            {
                Status = System.Net.HttpStatusCode.OK,
                Message = Resources.OkResponseES.SUCCESSFUL_PROCCESS,
                Data = default
            };
            return Task.FromResult(response);
        }
    }
}
