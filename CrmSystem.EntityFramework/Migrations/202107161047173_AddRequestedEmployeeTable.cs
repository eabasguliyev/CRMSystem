namespace CrmSystem.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequestedEmployeeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RequestedEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role = c.Int(nullable: false),
                        Profile = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        ImageLink = c.String(),
                        Phone = c.String(),
                        Mobile = c.String(),
                        Birthdate = c.DateTime(),
                        CreationDate = c.DateTime(),
                        AddressInfo_Id = c.Int(),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressInformations", t => t.AddressInfo_Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.AddressInfo_Id)
                .Index(t => t.Company_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestedEmployees", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.RequestedEmployees", "AddressInfo_Id", "dbo.AddressInformations");
            DropIndex("dbo.RequestedEmployees", new[] { "Company_Id" });
            DropIndex("dbo.RequestedEmployees", new[] { "AddressInfo_Id" });
            DropTable("dbo.RequestedEmployees");
        }
    }
}
