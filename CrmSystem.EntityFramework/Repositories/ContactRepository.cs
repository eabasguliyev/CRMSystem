using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CrmSystem.Domain.Models;
using CrmSystem.Domain.Repositories;

namespace CrmSystem.EntityFramework.Repositories
{
    public class ContactRepository:Repository<Contact>, IContactRepository
    {
        public ContactRepository(CrmSystemContext context) : base(context)
        {

        }

        public CrmSystemContext CrmSystemContext => Context as CrmSystemContext;

        public IEnumerable<Note> GetNotes(int id)
        {
            var contact = base.Get(id);

            if (contact == null)
                return null;            

            CrmSystemContext.ContactNotes.Where(n => n.ContactId == contact.Id).Load();

            return contact.Notes;
        }

        public IEnumerable<Task> GetOpenTasks(int id)
        {
            var contact = base.Get(id);

            if (contact == null)
                return null;

            CrmSystemContext.Tasks.Where(t => t.ContactId == contact.Id && t.Status != StatusOption.Completed).Load();

            return contact.Tasks;
        }

        public IEnumerable<Task> GetClosedTasks(int id)
        {
            var contact = base.Get(id);

            if (contact == null)
                return null;

            CrmSystemContext.Tasks.Where(t => t.ContactId == contact.Id && t.Status == StatusOption.Completed).Load();

            return contact.Tasks;
        }

        public IEnumerable<Contract> GetContracts(int id)
        {
            var contact = base.Get(id);

            if (contact == null)
                return null;

            CrmSystemContext.Contracts.Where(c => c.ContractId == contact.Id).Load();

            return contact.Contracts;
        }

        public new IEnumerable<Contact> GetAll()
        {
            return (base.GetAll() as DbSet<Contact>).Include(c => c.CreatedBy)
                .Include(c => c.CreatedBy.Employee)
                .Include(c => c.ModifiedBy)
                .Include(c => c.ModifiedBy.Employee)
                .Include(c => c.Owner);
        }
    }
}