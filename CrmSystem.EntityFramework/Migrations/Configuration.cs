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

            if (context.Employees.Count() == 0)
            {
                context.Employees.Add(new Employee()
                {
                    FirstName = "Elgun",
                    LastName = "Abasquliyev",
                    Birthdate = new DateTime(2000, 5, 11),
                    Email = "elgun@gmail.com",
                    Password = "8d4fb55a4e490e6b7ef3f0f80ce0fa3357fd9455cc25005470088a30a5c9617c",
                    Role = RoleOption.Ceo,
                    Profile = ProfileOption.SuperAdmin,
                    AddressInfo = new AddressInformation()
                    {
                        City = "Baku"
                    }
                });
            }

            if (context.Contacts.Count() == 0)
            {

                context.Contacts.AddRange(new List<Contact>()
                {
                    new Contact()
                    {
                        FirstName = "Resul",
                        LastName = "Osmanli",
                        Email = "resul@gmail.com",
                        CreatedBy = new RecordDetail()
                        {
                            EmployeeId = 1,
                            RecordDate = DateTime.Now
                        },
                        Birthdate = DateTime.Now.AddYears(-20),
                        OwnerId = 1
                    },
                    new Contact()
                    {
                        FirstName = "Senan",
                        LastName = "Memmedov",
                        Email = "senan2001@gmail.com",
                        CreatedBy = new RecordDetail()
                        {
                            EmployeeId = 1,
                            RecordDate = DateTime.Now
                        },
                        Birthdate = DateTime.Now.AddYears(-16),
                        OwnerId = 1
                    },
                });

            }


            if (context.LeadSources.Count() == 0)
            {

                context.LeadSources.AddRange(new List<LeadSource>()
                {
                    new LeadSource()
                    {
                        Name = "None",
                    },
                    new LeadSource()
                    {
                        Name = "Facebook",
                    },
                    new LeadSource()
                    {
                        Name = "Direct Phone Call",
                    },
                    new LeadSource()
                    {
                        Name = "Employee Referral",
                    },
                    new LeadSource()
                    {
                        Name = "Research On The Internet",
                    },
                });

            }

            if (context.Stages.Count() == 0)
            {

                context.Stages.AddRange(new List<Stage>()
                {
                    new Stage()
                    {
                        Name = "Evaluating"
                    },
                    new Stage()
                    {
                        Name = "Analysis Needed"
                    },
                    new Stage()
                    {
                        Name = "Value Recommended"
                    },
                    new Stage()
                    {
                        Name = "Identify Decision Makers"
                    },
                    new Stage()
                    {
                        Name = "Discussing/Evaluating"
                    },
                    new Stage()
                    {
                        Name = "Closed Won"
                    },
                    new Stage()
                    {
                        Name = "Closed Lost"
                    },
                    new Stage()
                    {
                        Name = "Closed-Lost in Competition"
                    },
                    new Stage()
                    {
                        Name = "Identify Decision Makers"
                    }
                });
            }

            if(context.ChangeTracker.HasChanges())
                context.SaveChanges();
        }


    }
}
