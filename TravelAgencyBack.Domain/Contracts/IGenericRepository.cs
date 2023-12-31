﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;

namespace TravelAgencyBack.Domain.Contracts
{
    public interface IGenericRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T? FirstOrDefault();
        T? LastOrDefault();
        T? Find(string id, bool ignoreAutoInclude = false);
        IEnumerable<T> FindBy(Func<T, bool> predicate, string includes = "");
        void Add(T entity);
        void AddRange(IEnumerable<T> entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        int Count();
    }
}
