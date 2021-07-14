using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using CrmSystem.Domain.Models;

namespace CrmSystem.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : DomainObject
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}