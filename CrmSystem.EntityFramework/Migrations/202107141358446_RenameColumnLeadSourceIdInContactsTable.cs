namespace CrmSystem.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameColumnLeadSourceIdInContactsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "LeadSource_Id", "dbo.LeadSources");
            DropIndex("dbo.Contacts", new[] { "LeadSource_Id" });
            RenameColumn(table: "dbo.Contacts", name: "LeadSource_Id", newName: "LeadSourceId");
            AlterColumn("dbo.Contacts", "LeadSourceId", c => c.Int(nullable: true));
            CreateIndex("dbo.Contacts", "LeadSourceId");
            AddForeignKey("dbo.Contacts", "LeadSourceId", "dbo.LeadSources", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "LeadSourceId", "dbo.LeadSources");
            DropIndex("dbo.Contacts", new[] { "LeadSourceId" });
            AlterColumn("dbo.Contacts", "LeadSourceId", c => c.Int());
            RenameColumn(table: "dbo.Contacts", name: "LeadSourceId", newName: "LeadSource_Id");
            CreateIndex("dbo.Contacts", "LeadSource_Id");
            AddForeignKey("dbo.Contacts", "LeadSource_Id", "dbo.LeadSources", "Id");
        }
    }
}
