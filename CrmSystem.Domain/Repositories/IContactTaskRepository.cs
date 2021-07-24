using System.Collections.Generic;
using CrmSystem.Domain.Models;

namespace CrmSystem.Domain.Repositories
{
    public interface IContactTaskRepository : IRepository<ContactTask>
    {
         IEnumerable<Note> GetNotes(int id);
    }
}