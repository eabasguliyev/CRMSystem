using System;
using System.Linq.Expressions;
using CrmSystem.Domain.Repositories;

namespace CrmSystem.Domain
{
    public interface IUnitOfWork:IDisposable
    {
        IContactRepository Contacts { get; }
        IEmployeeRepository Employees { get; }
        IContractRepository Contracts { get; }
        IProductRepository Products { get; }
        ITaskRepository Tasks { get; }



        //public void ExplicitLoading<TEntity2>(Expression<Func<TEntity2, bool>> predicate) where TEntity2 : class;
        void Save();
    }
}