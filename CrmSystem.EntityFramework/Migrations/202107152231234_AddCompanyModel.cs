namespace CrmSystem.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "Company_Id", c => c.Int());
            AddColumn("dbo.Contacts", "Company_Id", c => c.Int());
            AddColumn("dbo.Products", "Company_Id", c => c.Int());
            AddColumn("dbo.LeadSources", "Company_Id", c => c.Int());
            CreateIndex("dbo.Contacts", "Company_Id");
            CreateIndex("dbo.Employees", "Company_Id");
            CreateIndex("dbo.Products", "Company_Id");
            CreateIndex("dbo.LeadSources", "Company_Id");
            AddForeignKey("dbo.Contacts", "Company_Id", "dbo.Companies", "Id");
            AddForeignKey("dbo.Employees", "Company_Id", "dbo.Companies", "Id");
            AddForeignKey("dbo.LeadSources", "Company_Id", "dbo.Companies", "Id");
            AddForeignKey("dbo.Products", "Company_Id", "dbo.Companies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.LeadSources", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Employees", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Contacts", "Company_Id", "dbo.Companies");
            DropIndex("dbo.LeadSources", new[] { "Company_Id" });
            DropIndex("dbo.Products", new[] { "Company_Id" });
            DropIndex("dbo.Employees", new[] { "Company_Id" });
            DropIndex("dbo.Contacts", new[] { "Company_Id" });
            DropColumn("dbo.LeadSources", "Company_Id");
            DropColumn("dbo.Products", "Company_Id");
            DropColumn("dbo.Contacts", "Company_Id");
            DropColumn("dbo.Employees", "Company_Id");
            DropTable("dbo.Companies");
        }
    }
}
