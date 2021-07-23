using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CrmSystem.Domain.Models;
using CrmSystem.Domain.Repositories;

namespace CrmSystem.EntityFramework.Repositories
{
    public class ContractRepository:Repository<Contract>, IContractRepository
    {
        public CrmSystemContext CrmSystemContext => Context as CrmSystemContext;
        public ContractRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<Contract> Find(Expression<Func<Contract, bool>> predicate)
        {
            return CrmSystemContext.Set<Contract>().Include(c => c.Company).Where(predicate)
                .Include(c => c.Contact)
                .Include(c => c.Owner)
                .Include(c => c.ModifiedBy)
                .Include(c => c.CreatedBy)
                .Include(c => c.Stage)
                .Include(c => c.LeadSource);
        }
    }

}