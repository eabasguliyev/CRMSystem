using System.Data.Entity.ModelConfiguration;
using CrmSystem.Domain.Models;

namespace CrmSystem.EntityFramework.EntityConfigurations
{
    public class ContactConfiguration:EntityTypeConfiguration<Contact>
    {
        public ContactConfiguration()
        {

        }
    }
}