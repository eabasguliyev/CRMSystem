using System.Collections.Generic;
using System.Transactions;
using CrmSystem.Domain.Models;

namespace CrmSystem.Domain.Repositories
{
    public interface IContactRepository:IRepository<Contact>
    {
        IEnumerable<Note> GetNotes(int id);

        IEnumerable<ContactTask> GetOpenTasks(int id);
        IEnumerable<ContactTask> GetClosedTasks(int id);
        IEnumerable<Contract> GetContracts(int id);
    }
}