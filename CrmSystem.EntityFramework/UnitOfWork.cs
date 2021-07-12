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

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}