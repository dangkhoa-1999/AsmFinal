namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trainers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Trainers", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Trainers", "TrainerId");
            DropColumn("dbo.Trainers", "ApplicationUser_Id");
            DropColumn("dbo.AspNetUsers", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Trainers", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Trainers", "TrainerId", c => c.String());
            CreateIndex("dbo.Trainers", "ApplicationUser_Id");
            AddForeignKey("dbo.Trainers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
