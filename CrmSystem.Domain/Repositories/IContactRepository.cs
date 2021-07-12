using System.Collections.Generic;
using System.Transactions;
using CrmSystem.Domain.Models;

namespace CrmSystem.Domain.Repositories
{
    public interface IContactRepository:IRepository<Contact>
    {
        IEnumerable<Note> GetNotes(int id);

        IEnumerable<Task> GetOpenTasks(int id);
        IEnumerable<Task> GetClosedTasks(int id);
        IEnumerable<Contract> GetContracts(int id);
    }
}