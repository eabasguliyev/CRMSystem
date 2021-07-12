using System.Data.Entity.Infrastructure;

namespace CrmSystem.EntityFramework
{
    public class CrmSystemContextFactory:IDbContextFactory<CrmSystemContext>
    {
        private static CrmSystemContext _context;
        public CrmSystemContext Create()
        {
            return _context ??= new CrmSystemContext(Properties.Resources.ResourceManager.GetString("ConnectionString"));
        }
    }
}