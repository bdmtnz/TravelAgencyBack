using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;

namespace TravelAgencyBack.Domain.Contracts
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T : Entity; 

        void Commit();
        void Rollback();
        void BeginTransaction();
    }
}
