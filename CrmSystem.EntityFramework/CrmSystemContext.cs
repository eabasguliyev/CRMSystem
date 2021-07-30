using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using CrmSystem.Domain.Models;

namespace CrmSystem.EntityFramework
{
    public class CrmSystemContext:DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Contract> Contracts {get; set; }
        public DbSet<Employee> Employees {get; set; }
        public DbSet<Product> Products {get; set; }
        public DbSet<ContactTask> ContactTasks { get; set; }
        public DbSet<ContactNote> ContactNotes { get; set; }
        public DbSet<TaskNote> TaskNotes { get; set; }
        public DbSet<LeadSource> LeadSources { get; set; }
        public DbSet<RequestedEmployee> RequestedEmployees { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public CrmSystemContext():base(Properties.Resources.ResourceManager.GetString("ConnectionString"))
        {
            base.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // TODO: add configurations.
            modelBuilder.Entity<Contact>().Ignore(c => c.FullName);

            modelBuilder.Entity<Employee>().Ignore(e => e.FullName);

            //modelBuilder.Entity<Contact>().Property(c => c.Birthdate).IsOptional();

            //modelBuilder.Entity<Employee>().Property(p => p.Email)
            //    .HasColumnAnnotation("Index", new IndexAnnotation(new[] {
            //            new IndexAttribute("Index") { IsUnique = true }
            //        }
            //    ));
            //modelBuilder.Entity<Contact>().Property(p => p.Email)
            //    .HasColumnAnnotation("Index", new IndexAnnotation(new[] {
            //            new IndexAttribute("Index") { IsUnique = true }
            //        }
            //    ));
            base.OnModelCreating(modelBuilder);
        }
    }
}