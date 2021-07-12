namespace CrmSystem.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        Text = c.String(),
                        CreatedBy_Id = c.Int(),
                        ModifiedBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RecordDetails", t => t.CreatedBy_Id)
                .ForeignKey("dbo.RecordDetails", t => t.ModifiedBy_Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: false)
                .Index(t => t.ContactId)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.ModifiedBy_Id);
            
            CreateTable(
                "dbo.RecordDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecordDate = c.DateTime(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        Role = c.Int(nullable: false),
                        Profile = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        ImageLink = c.String(),
                        Phone = c.String(),
                        Mobile = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        AddressInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressInformations", t => t.AddressInfo_Id)
                .Index(t => t.AddressInfo_Id);
            
            CreateTable(
                "dbo.AddressInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        ImageLink = c.String(),
                        Phone = c.String(),
                        Mobile = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        AddressInfo_Id = c.Int(),
                        CreatedBy_Id = c.Int(),
                        ModifiedBy_Id = c.Int(),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressInformations", t => t.AddressInfo_Id)
                .ForeignKey("dbo.RecordDetails", t => t.CreatedBy_Id)
                .ForeignKey("dbo.RecordDetails", t => t.ModifiedBy_Id)
                .ForeignKey("dbo.Employees", t => t.Owner_Id)
                .Index(t => t.AddressInfo_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.ModifiedBy_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContractId = c.Int(nullable: false),
                        ContractDate = c.DateTime(nullable: false),
                        SaleType = c.Int(nullable: false),
                        Contact_Id = c.Int(),
                        CreatedBy_Id = c.Int(),
                        ModifiedBy_Id = c.Int(),
                        Owner_Id = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id)
                .ForeignKey("dbo.RecordDetails", t => t.CreatedBy_Id)
                .ForeignKey("dbo.RecordDetails", t => t.ModifiedBy_Id)
                .ForeignKey("dbo.Employees", t => t.Owner_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Contact_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.ModifiedBy_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        Category = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        Priority = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Description = c.String(),
                        CreatedBy_Id = c.Int(),
                        ModifiedBy_Id = c.Int(),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.RecordDetails", t => t.CreatedBy_Id)
                .ForeignKey("dbo.RecordDetails", t => t.ModifiedBy_Id)
                .ForeignKey("dbo.Employees", t => t.Owner_Id)
                .Index(t => t.ContactId)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.ModifiedBy_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.TaskNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskId = c.Int(nullable: false),
                        Text = c.String(),
                        CreatedBy_Id = c.Int(),
                        ModifiedBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RecordDetails", t => t.CreatedBy_Id)
                .ForeignKey("dbo.RecordDetails", t => t.ModifiedBy_Id)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.ModifiedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Owner_Id", "dbo.Employees");
            DropForeignKey("dbo.TaskNotes", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.TaskNotes", "ModifiedBy_Id", "dbo.RecordDetails");
            DropForeignKey("dbo.TaskNotes", "CreatedBy_Id", "dbo.RecordDetails");
            DropForeignKey("dbo.Tasks", "ModifiedBy_Id", "dbo.RecordDetails");
            DropForeignKey("dbo.Tasks", "CreatedBy_Id", "dbo.RecordDetails");
            DropForeignKey("dbo.Tasks", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "Owner_Id", "dbo.Employees");
            DropForeignKey("dbo.ContactNotes", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "ModifiedBy_Id", "dbo.RecordDetails");
            DropForeignKey("dbo.Contacts", "CreatedBy_Id", "dbo.RecordDetails");
            DropForeignKey("dbo.Contracts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Contracts", "Owner_Id", "dbo.Employees");
            DropForeignKey("dbo.Contracts", "ModifiedBy_Id", "dbo.RecordDetails");
            DropForeignKey("dbo.Contracts", "CreatedBy_Id", "dbo.RecordDetails");
            DropForeignKey("dbo.Contracts", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "AddressInfo_Id", "dbo.AddressInformations");
            DropForeignKey("dbo.ContactNotes", "ModifiedBy_Id", "dbo.RecordDetails");
            DropForeignKey("dbo.ContactNotes", "CreatedBy_Id", "dbo.RecordDetails");
            DropForeignKey("dbo.RecordDetails", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "AddressInfo_Id", "dbo.AddressInformations");
            DropIndex("dbo.TaskNotes", new[] { "ModifiedBy_Id" });
            DropIndex("dbo.TaskNotes", new[] { "CreatedBy_Id" });
            DropIndex("dbo.TaskNotes", new[] { "TaskId" });
            DropIndex("dbo.Tasks", new[] { "Owner_Id" });
            DropIndex("dbo.Tasks", new[] { "ModifiedBy_Id" });
            DropIndex("dbo.Tasks", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Tasks", new[] { "ContactId" });
            DropIndex("dbo.Contracts", new[] { "Product_Id" });
            DropIndex("dbo.Contracts", new[] { "Owner_Id" });
            DropIndex("dbo.Contracts", new[] { "ModifiedBy_Id" });
            DropIndex("dbo.Contracts", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Contracts", new[] { "Contact_Id" });
            DropIndex("dbo.Contacts", new[] { "Owner_Id" });
            DropIndex("dbo.Contacts", new[] { "ModifiedBy_Id" });
            DropIndex("dbo.Contacts", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Contacts", new[] { "AddressInfo_Id" });
            DropIndex("dbo.Employees", new[] { "AddressInfo_Id" });
            DropIndex("dbo.RecordDetails", new[] { "Employee_Id" });
            DropIndex("dbo.ContactNotes", new[] { "ModifiedBy_Id" });
            DropIndex("dbo.ContactNotes", new[] { "CreatedBy_Id" });
            DropIndex("dbo.ContactNotes", new[] { "ContactId" });
            DropTable("dbo.TaskNotes");
            DropTable("dbo.Tasks");
            DropTable("dbo.Products");
            DropTable("dbo.Contracts");
            DropTable("dbo.Contacts");
            DropTable("dbo.AddressInformations");
            DropTable("dbo.Employees");
            DropTable("dbo.RecordDetails");
            DropTable("dbo.ContactNotes");
        }
    }
}
