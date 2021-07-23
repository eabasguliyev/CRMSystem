using System.Data.Entity;
using CrmSystem.Domain.Models;
using CrmSystem.Domain.Repositories;

namespace CrmSystem.EntityFramework.Repositories
{
    public class StageRepository : Repository<Stage>, IStageRepository
    {
        public CrmSystemContext CrmSystemContext => Context as CrmSystemContext;
        public StageRepository(DbContext context) : base(context)
        {
        }
    }
}