using Microsoft.EntityFrameworkCore;
using System.Reflection;
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
            _dbset.Add(entity);
        }

        public void AddRange(IEnumerable<T> entity)
        {
            _dbset.AddRange(entity);
        }

        public T? Find(string id)
        {
            return _dbset.Find(id);
        }

        public IEnumerable<T> FindBy(Func<T, bool> predicate, string includes = "")
        {
            return FindBy(predicate, includes);
        }

        public T? FirstOrDefault()
        {
            return _dbset.FirstOrDefault();
        }

        public T? LastOrDefault()
        {
            return _dbset.LastOrDefault();
        }

        //public IEnumerable<D> NativeQuery<D>(string query)
        //{
        //    var command = _context.Database.GetDbConnection().CreateCommand();
        //    command.CommandText = query;
        //    _db.Database.OpenConnection();
        //    var result = command.ExecuteReader();
        //    List<T> list = new List<T>();
        //    T obj = default(T);
        //    while (result.Read())
        //    {
        //        obj = Activator.CreateInstance<T>();
        //        foreach (PropertyInfo prop in obj.GetType().GetProperties())
        //        {
        //            bool propValid = true;
        //            try
        //            {
        //                object data = result[prop.Name];
        //            }
        //            catch (Exception e) { propValid = false; }
        //            if (propValid)
        //            {
        //                if (!object.Equals(result[prop.Name], DBNull.Value))
        //                {
        //                    prop.SetValue(obj, result[prop.Name], null);
        //                }
        //            }
        //        }
        //        list.Add(obj);
        //    }
        //    return list;
        //}

        public void Remove(T entity)
        {
            _dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            _dbset.RemoveRange(entity);
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }
    }
}