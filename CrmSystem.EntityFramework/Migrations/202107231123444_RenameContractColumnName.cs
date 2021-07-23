namespace CrmSystem.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameContractColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "ClosingDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Contracts", "ContractDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contracts", "ContractDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Contracts", "ClosingDate");
        }
    }
}
