using System;
using CrmSystem.Domain.Repositories;

namespace CrmSystem.Domain
{
    public interface IUnitOfWork:IDisposable
    {
        IContactRepository Contacts { get; }
        IEmployeeRepository Employees { get; }
        IContractRepository Contracts { get; }
        IProductRepository Products { get; }

        void Save();
    }
}