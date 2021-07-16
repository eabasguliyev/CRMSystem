namespace CrmSystem.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreationColumnToContactAndEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "CreationDate", c => c.DateTime());
            AddColumn("dbo.Contacts", "CreationDate", c => c.DateTime());
            AlterColumn("dbo.Employees", "Birthdate", c => c.DateTime());
            AlterColumn("dbo.Contacts", "Birthdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Birthdate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "Birthdate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Contacts", "CreationDate");
            DropColumn("dbo.Employees", "CreationDate");
        }
    }
}
