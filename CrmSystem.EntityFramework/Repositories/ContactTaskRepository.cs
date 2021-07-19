using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CrmSystem.Domain.Models;
using CrmSystem.Domain.Repositories;

namespace CrmSystem.EntityFramework.Repositories
{
    public class ContactTaskRepository : Repository<ContactTask>, IContactTaskRepository
    {
        public CrmSystemContext CrmSystemContext => Context as CrmSystemContext;

        public ContactTaskRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<ContactTask> Find(Expression<Func<ContactTask, bool>> predicate)
        {
            return CrmSystemContext.Set<ContactTask>().Include(e => e.Contact)
                .Include(e => e.Owner).Where(predicate);
        }
    }
}