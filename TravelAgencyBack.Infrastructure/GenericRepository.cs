﻿using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
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

        public T? Find(string id, bool ignoreAutoInclude = false)
        {
            var queriable = _dbset.AsQueryable();
            if(ignoreAutoInclude) queriable.IgnoreAutoIncludes();
            return queriable.FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<T> FindBy(Func<T, bool> predicate, string includes = "")
        {
            var query = _dbset.AsQueryable();
            if (!string.IsNullOrEmpty(includes)) {
                query.IgnoreAutoIncludes().Include(includes);
            }

            return query.Where(predicate);
        }

        public T? FirstOrDefault()
        {
            return _dbset.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
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