using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CrmSystem.Domain.Models;
using CrmSystem.Domain.Repositories;

namespace CrmSystem.EntityFramework.Repositories
{
    public class RequestedEmployeeRepository : Repository<RequestedEmployee>, IRequestedEmployeeRepository
    {
        public RequestedEmployeeRepository(CrmSystemContext context) : base(context)
        {
        }

        public CrmSystemContext CrmSystemContext => Context as CrmSystemContext;
        public override RequestedEmployee SingleOrDefault(Expression<Func<RequestedEmployee, bool>> predicate)
        {
            return CrmSystemContext.Set<RequestedEmployee>().Include(e => e.Company)
                .Include(e => e.AddressInfo).SingleOrDefault(predicate);
        }

        public override IEnumerable<RequestedEmployee> Find(Expression<Func<RequestedEmployee, bool>> predicate)
        {
            return CrmSystemContext.Set<RequestedEmployee>().Include(e => e.Company).Where(predicate);
        }
    }
}