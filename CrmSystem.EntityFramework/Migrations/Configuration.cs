using System.Collections.Generic;
using CrmSystem.Domain.Models;

namespace CrmSystem.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CrmSystem.EntityFramework.CrmSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CrmSystem.EntityFramework.CrmSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            
            
            //context.Employees.Add(new Employee()
            //{
            //    FirstName = "Elgun",
            //    LastName = "Abasquliyev",
            //    Birthdate = new DateTime(2000, 5, 11),
            //    Email = "elgun@gmail.com",
            //    Password = "elgun",
            //    AddressInfo = new AddressInformation()
            //    {
            //        City = "Baku"
            //    }
            //});

            //context.Contacts.AddRange(new List<Contact>()
            //{
            //    new Contact()
            //    {
            //        FirstName = "Resul",
            //        LastName = "Osmanli",
            //        Email = "resul@gmail.com",
            //        CreatedBy = new RecordDetail()
            //        {
            //            EmployeeId = 1,
            //            RecordDate = DateTime.Now
            //        },
            //        Birthdate = DateTime.Now.AddYears(-20),
            //        OwnerId = 1
            //    },
            //    new Contact()
            //    {
            //        FirstName = "Senan",
            //        LastName = "Memmedov",
            //        Email = "senan2001@gmail.com",
            //        CreatedBy = new RecordDetail()
            //        {
            //            EmployeeId = 1,
            //            RecordDate = DateTime.Now
            //        },
            //        Birthdate = DateTime.Now.AddYears(-16),
            //        OwnerId = 1
            //    },
            //});

            //context.SaveChanges();
        }
    }
}
