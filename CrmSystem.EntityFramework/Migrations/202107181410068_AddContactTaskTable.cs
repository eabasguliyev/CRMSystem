namespace CrmSystem.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactTaskTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tasks", newName: "ContactTasks");
            DropForeignKey("dbo.TaskNotes", "TaskId", "dbo.Tasks");
            DropIndex("dbo.TaskNotes", new[] { "TaskId" });
            AddColumn("dbo.TaskNotes", "ContactTask_Id", c => c.Int());
            CreateIndex("dbo.TaskNotes", "ContactTask_Id");
            AddForeignKey("dbo.TaskNotes", "ContactTask_Id", "dbo.ContactTasks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskNotes", "ContactTask_Id", "dbo.ContactTasks");
            DropIndex("dbo.TaskNotes", new[] { "ContactTask_Id" });
            DropColumn("dbo.TaskNotes", "ContactTask_Id");
            CreateIndex("dbo.TaskNotes", "TaskId");
            AddForeignKey("dbo.TaskNotes", "TaskId", "dbo.Tasks", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.ContactTasks", newName: "Tasks");
        }
    }
}
