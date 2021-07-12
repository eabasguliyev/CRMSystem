using System.Data.Entity.Infrastructure;

namespace CrmSystem.EntityFramework
{
    public class CrmSystemContextFactory:IDbContextFactory<CrmSystemContext>
    {
        public CrmSystemContext Create()
        {
            return new CrmSystemContext(Properties.Resources.ResourceManager.GetString("ConnectionString"));
        }
    }
}