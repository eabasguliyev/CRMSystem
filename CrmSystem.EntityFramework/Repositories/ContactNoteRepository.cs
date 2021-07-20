using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CrmSystem.Domain.Models;
using CrmSystem.Domain.Repositories;

namespace CrmSystem.EntityFramework.Repositories
{
    public class ContactNoteRepository : Repository<ContactNote>, IContactNoteRepository
    {
        public CrmSystemContext CrmSystemContext => Context as CrmSystemContext;
        public ContactNoteRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<ContactNote> Find(Expression<Func<ContactNote, bool>> predicate)
        {
            return CrmSystemContext.Set<ContactNote>().Include(cn => cn.Contact)
                .Include(cn => cn.Contact.Company).Where(predicate)
                .Include(cn => cn.CreatedBy)
                .Include(cn => cn.ModifiedBy);
        }
    }
}