using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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


        public IEnumerable<Contact> GetAll(int companyId)
        {
            return (base.GetAll() as DbSet<Contact>).Include(c => c.Company)
                .Where(c => c.Company.Id == companyId).ToList();
        }
        public IEnumerable<Note> GetNotes(int id)
        {
            var contact = base.Get(id);

            if (contact == null)
                return null;            

            CrmSystemContext.ContactNotes.Where(n => n.ContactId == contact.Id).Load();

            return contact.Notes;
        }

        public IEnumerable<ContactTask> GetOpenTasks(int id)
        {
            var contact = base.Get(id);

            if (contact == null)
                return null;

            CrmSystemContext.Tasks.Where(t => t.ContactId == contact.Id && t.Status != StatusOption.Completed).Load();

            return contact.Tasks;
        }

        public IEnumerable<ContactTask> GetClosedTasks(int id)
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
                .Include(c => c.Owner)
                .Include(c => c.Company);
        }
    }
}