namespace CrmSystem.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewColumnsToContractTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contracts", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contracts", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Contracts", "ExpectedRevenue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Contracts", "Description", c => c.String());
            AddColumn("dbo.Contracts", "Stage_Id", c => c.Int());
            CreateIndex("dbo.Contracts", "Stage_Id");
            AddForeignKey("dbo.Contracts", "Stage_Id", "dbo.Stages", "Id");
            DropColumn("dbo.Contracts", "SaleType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contracts", "SaleType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Contracts", "Stage_Id", "dbo.Stages");
            DropIndex("dbo.Contracts", new[] { "Stage_Id" });
            DropColumn("dbo.Contracts", "Stage_Id");
            DropColumn("dbo.Contracts", "Description");
            DropColumn("dbo.Contracts", "ExpectedRevenue");
            DropColumn("dbo.Contracts", "Amount");
            DropColumn("dbo.Contracts", "StartDate");
            DropTable("dbo.Stages");
        }
    }
}
