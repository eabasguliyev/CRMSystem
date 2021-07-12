using System.Data.Entity;
using CrmSystem.Domain.Models;

namespace CrmSystem.EntityFramework
{
    public class CrmSystemContext:DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Contract> Contracts {get; set; }
        public DbSet<Employee> Employees {get; set; }
        public DbSet<Product> Products {get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<ContactNote> ContactNotes { get; set; }
        public DbSet<TaskNote> TaskNotes { get; set; }


        public CrmSystemContext(string connectionString):base(connectionString)
        {
            base.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // TODO: add configurations.

            base.OnModelCreating(modelBuilder);
        }
    }
}