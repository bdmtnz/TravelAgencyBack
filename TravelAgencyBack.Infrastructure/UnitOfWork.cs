using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TravelAgencyContext _context;
        public UnitOfWork(TravelAgencyContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GenericRepository<T>() where T : Entity
        {
            return new GenericRepository<T>(_context);
        }

        public void BeginTransaction()
        {
            return;
        }

        public void Commit()
        {
            _context.SaveChanges();
            return;
        }

        public void Rollback()
        {
            return;
        }
    }
}
