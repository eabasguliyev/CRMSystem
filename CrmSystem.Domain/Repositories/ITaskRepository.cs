using System.Collections.Generic;
using CrmSystem.Domain.Models;

namespace CrmSystem.Domain.Repositories
{
    public interface ITaskRepository:IRepository<Task>
    {
        IEnumerable<Task> GetAllOpenTasks();
        IEnumerable<Task> GetAllClosedTasks();
    }
}