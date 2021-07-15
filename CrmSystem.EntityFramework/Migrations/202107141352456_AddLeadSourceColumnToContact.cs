namespace CrmSystem.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLeadSourceColumnToContact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeadSources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contacts", "LeadSource_Id", c => c.Int());
            CreateIndex("dbo.Contacts", "LeadSource_Id");
            AddForeignKey("dbo.Contacts", "LeadSource_Id", "dbo.LeadSources", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "LeadSource_Id", "dbo.LeadSources");
            DropIndex("dbo.Contacts", new[] { "LeadSource_Id" });
            DropColumn("dbo.Contacts", "LeadSource_Id");
            DropTable("dbo.LeadSources");
        }
    }
}
