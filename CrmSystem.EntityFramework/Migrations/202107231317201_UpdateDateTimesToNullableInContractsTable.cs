namespace CrmSystem.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDateTimesToNullableInContractsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contracts", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Contracts", "ClosingDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contracts", "ClosingDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contracts", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
