using System;
using System.Linq.Expressions;
using CrmSystem.Domain.Models;
using CrmSystem.Domain.Repositories;

namespace CrmSystem.Domain
{

    public interface IUnitOfWork:IDisposable
    {
        IContactRepository Contacts { get; }
        IEmployeeRepository Employees { get; }
        IContractRepository Contracts { get; }
        IRepository<Product> Products { get; }
        IContactTaskRepository ContactTasks { get; }
        IRepository<LeadSource> LeadSources { get; }
        IRepository<Company> Companies { get; }
        IRequestedEmployeeRepository RequestedEmployees { get; }
        IContactNoteRepository ContactNotes { get; }


        //public void ExplicitLoading<TEntity2>(Expression<Func<TEntity2, bool>> predicate) where TEntity2 : class;
        void Save();
    }
}