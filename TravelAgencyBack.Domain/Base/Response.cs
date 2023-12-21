using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyBack.Domain.Base
{
    public abstract class Response<T>
    {
        public string Message { get; set; }
        public T? Data { get; set; }
        public Response() { }
    }

    public class DomainResponse<T> : Response<T> where T : Entity
    {
        public bool HaveError { get; private set; }

        public DomainResponse(bool haveError, string message, T? data)
        {
            HaveError = haveError;
            Message = message;
            Data = data;
        }
    }
}
