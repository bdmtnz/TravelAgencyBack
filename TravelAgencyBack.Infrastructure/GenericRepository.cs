using Microsoft.EntityFrameworkCore;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IStorable
    {
        private readonly TravelAgencyContext _context;
        private readonly DbSet<T> _dbset;

        public GenericRepository(TravelAgencyContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public T? Find(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindBy(Func<T, bool> predicate, string includes = "")
        {
            throw new NotImplementedException();
        }

        public T? FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public T? LastOrDefault()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<D> NativeQuery<D>(string query)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveBy(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}