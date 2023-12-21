using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyBack.Domain.Contracts
{
    public interface IUnitOfWork<T> where T : IEntity
    {
        T? FirstOrDefault();
        T? LastOrDefault();
        T? Find(string id);
        IEnumerable<T> FindBy(Func<T, bool> predicate, string includes = "");
        void Add(T entity);
        void AddRange(IEnumerable<T> entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveBy(Func<T, bool> predicate);
        IEnumerable<D> NativeQuery<D>(string query);

        void Commit();
        void Rollback();
        void BeginTransaction();
    }
}
