namespace CrmSystem.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTaskNotesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TaskNotes", "ContactTask_Id", "dbo.ContactTasks");
            DropIndex("dbo.TaskNotes", new[] { "ContactTask_Id" });
            DropColumn("dbo.TaskNotes", "TaskId");
            RenameColumn(table: "dbo.TaskNotes", name: "ContactTask_Id", newName: "TaskId");
            AlterColumn("dbo.TaskNotes", "TaskId", c => c.Int(nullable: false));
            CreateIndex("dbo.TaskNotes", "TaskId");
            AddForeignKey("dbo.TaskNotes", "TaskId", "dbo.ContactTasks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskNotes", "TaskId", "dbo.ContactTasks");
            DropIndex("dbo.TaskNotes", new[] { "TaskId" });
            AlterColumn("dbo.TaskNotes", "TaskId", c => c.Int());
            RenameColumn(table: "dbo.TaskNotes", name: "TaskId", newName: "ContactTask_Id");
            AddColumn("dbo.TaskNotes", "TaskId", c => c.Int(nullable: false));
            CreateIndex("dbo.TaskNotes", "ContactTask_Id");
            AddForeignKey("dbo.TaskNotes", "ContactTask_Id", "dbo.ContactTasks", "Id");
        }
    }
}
