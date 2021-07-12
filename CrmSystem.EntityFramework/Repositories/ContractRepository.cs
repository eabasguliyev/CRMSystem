using System.Collections.Generic;
using System.Data.Entity;
using CrmSystem.Domain.Models;
using CrmSystem.Domain.Repositories;

namespace CrmSystem.EntityFramework.Repositories
{
    public class ContractRepository:Repository<Contract>, IContractRepository
    {
        public ContractRepository(DbContext context) : base(context)
        {
        }
    }
}