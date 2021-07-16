namespace CrmSystem.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyColumnsToModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "Company_Id", c => c.Int());
            CreateIndex("dbo.Contracts", "Company_Id");
            AddForeignKey("dbo.Contracts", "Company_Id", "dbo.Companies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Contracts", new[] { "Company_Id" });
            DropColumn("dbo.Contracts", "Company_Id");
        }
    }
}
