using System.Data.Entity;
using CrmSystem.Domain.Models;
using CrmSystem.Domain.Repositories;

namespace CrmSystem.EntityFramework.Repositories
{
    public class ContractNoteRepository : Repository<ContractNote>, IContractNoteRepository
    {
        public ContractNoteRepository(DbContext context) : base(context)
        {
        }
    }
}