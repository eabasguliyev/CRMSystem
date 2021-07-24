using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CrmSystem.Domain.Models;
using CrmSystem.Domain.Repositories;

namespace CrmSystem.EntityFramework.Repositories
{
    public class TaskNoteRepository : Repository<TaskNote>, ITaskNoteRepository
    {
        public TaskNoteRepository(DbContext context) : base(context)
        {
        }

        public CrmSystemContext CrmSystemContext => Context as CrmSystemContext;

        
    }
}