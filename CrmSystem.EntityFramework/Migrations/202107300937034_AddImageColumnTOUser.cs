namespace CrmSystem.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageColumnTOUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Image", c => c.Binary());
            AddColumn("dbo.Employees", "Image", c => c.Binary());
            AddColumn("dbo.RequestedEmployees", "Image", c => c.Binary());
            DropColumn("dbo.Contacts", "ImageLink");
            DropColumn("dbo.Employees", "ImageLink");
            DropColumn("dbo.RequestedEmployees", "ImageLink");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RequestedEmployees", "ImageLink", c => c.String());
            AddColumn("dbo.Employees", "ImageLink", c => c.String());
            AddColumn("dbo.Contacts", "ImageLink", c => c.String());
            DropColumn("dbo.RequestedEmployees", "Image");
            DropColumn("dbo.Employees", "Image");
            DropColumn("dbo.Contacts", "Image");
        }
    }
}
