using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyBack.Domain.Contracts
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T : class, IStorable; 

        void Commit();
        void Rollback();
        void BeginTransaction();
    }
}
