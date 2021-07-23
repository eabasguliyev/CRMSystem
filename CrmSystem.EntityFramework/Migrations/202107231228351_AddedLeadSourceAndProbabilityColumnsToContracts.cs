namespace CrmSystem.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLeadSourceAndProbabilityColumnsToContracts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "Probability", c => c.Int(nullable: false));
            AddColumn("dbo.Contracts", "LeadSource_Id", c => c.Int());
            CreateIndex("dbo.Contracts", "LeadSource_Id");
            AddForeignKey("dbo.Contracts", "LeadSource_Id", "dbo.LeadSources", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "LeadSource_Id", "dbo.LeadSources");
            DropIndex("dbo.Contracts", new[] { "LeadSource_Id" });
            DropColumn("dbo.Contracts", "LeadSource_Id");
            DropColumn("dbo.Contracts", "Probability");
        }
    }
}
