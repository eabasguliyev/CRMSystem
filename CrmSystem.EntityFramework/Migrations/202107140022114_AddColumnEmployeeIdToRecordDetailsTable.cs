namespace CrmSystem.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnEmployeeIdToRecordDetailsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecordDetails", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.RecordDetails", new[] { "Employee_Id" });
            RenameColumn(table: "dbo.RecordDetails", name: "Employee_Id", newName: "EmployeeId");
            AlterColumn("dbo.RecordDetails", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.RecordDetails", "EmployeeId");
            AddForeignKey("dbo.RecordDetails", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecordDetails", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.RecordDetails", new[] { "EmployeeId" });
            AlterColumn("dbo.RecordDetails", "EmployeeId", c => c.Int());
            RenameColumn(table: "dbo.RecordDetails", name: "EmployeeId", newName: "Employee_Id");
            CreateIndex("dbo.RecordDetails", "Employee_Id");
            AddForeignKey("dbo.RecordDetails", "Employee_Id", "dbo.Employees", "Id");
        }
    }
}
