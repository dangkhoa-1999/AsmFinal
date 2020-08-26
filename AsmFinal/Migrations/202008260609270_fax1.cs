namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fax1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Trainers", name: "Application_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Trainers", name: "IX_Application_Id", newName: "IX_ApplicationUser_Id");
            AddColumn("dbo.AspNetUsers", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserId");
            RenameIndex(table: "dbo.Trainers", name: "IX_ApplicationUser_Id", newName: "IX_Application_Id");
            RenameColumn(table: "dbo.Trainers", name: "ApplicationUser_Id", newName: "Application_Id");
        }
    }
}
