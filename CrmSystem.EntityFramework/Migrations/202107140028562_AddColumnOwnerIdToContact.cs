namespace CrmSystem.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnOwnerIdToContact : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "Owner_Id", "dbo.Employees");
            DropIndex("dbo.Contacts", new[] { "Owner_Id" });
            RenameColumn(table: "dbo.Contacts", name: "Owner_Id", newName: "OwnerId");
            AlterColumn("dbo.Contacts", "OwnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "OwnerId");
            AddForeignKey("dbo.Contacts", "OwnerId", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "OwnerId", "dbo.Employees");
            DropIndex("dbo.Contacts", new[] { "OwnerId" });
            AlterColumn("dbo.Contacts", "OwnerId", c => c.Int());
            RenameColumn(table: "dbo.Contacts", name: "OwnerId", newName: "Owner_Id");
            CreateIndex("dbo.Contacts", "Owner_Id");
            AddForeignKey("dbo.Contacts", "Owner_Id", "dbo.Employees", "Id");
        }
    }
}
