using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CrmSystem.Domain;
using CrmSystem.Domain.Repositories;

namespace CrmSystem.EntityFramework
{
    public class UnitOfWork:IUnitOfWork
    {
        private CrmSystemContext _context;

        public UnitOfWork(CrmSystemContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IContactRepository Contacts { get; }
        public IEmployeeRepository Employees { get; }
        public IContractRepository Contracts { get; }
        public IProductRepository Products { get; }
        public ITaskRepository Tasks { get; }

        //public void ExplicitLoading<TEntity2>(Expression<Func<TEntity2, bool>> predicate) where TEntity2 : class
        //{
        //    _context.Set<TEntity2>().Where(predicate).Load();
        //}

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}