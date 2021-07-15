namespace CrmSystem.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameColumnLeadSourceIdInContactsTable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "LeadSourceId", "dbo.LeadSources");
            DropIndex("dbo.Contacts", new[] { "LeadSourceId" });
            AlterColumn("dbo.Contacts", "LeadSourceId", c => c.Int());
            CreateIndex("dbo.Contacts", "LeadSourceId");
            AddForeignKey("dbo.Contacts", "LeadSourceId", "dbo.LeadSources", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "LeadSourceId", "dbo.LeadSources");
            DropIndex("dbo.Contacts", new[] { "LeadSourceId" });
            AlterColumn("dbo.Contacts", "LeadSourceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "LeadSourceId");
            AddForeignKey("dbo.Contacts", "LeadSourceId", "dbo.LeadSources", "Id", cascadeDelete: true);
        }
    }
}
