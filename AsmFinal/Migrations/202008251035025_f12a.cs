namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f12a : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trainers", "TopicId", "dbo.Topics");
            DropIndex("dbo.Trainers", new[] { "TopicId" });
            RenameColumn(table: "dbo.Trainers", name: "TrainerUser_Id", newName: "Application_Id");
            RenameIndex(table: "dbo.Trainers", name: "IX_TrainerUser_Id", newName: "IX_Application_Id");
            AddColumn("dbo.Trainers", "TrainerId", c => c.Int(nullable: false));
            DropColumn("dbo.Trainers", "TopicId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainers", "TopicId", c => c.Int(nullable: false));
            DropColumn("dbo.Trainers", "TrainerId");
            RenameIndex(table: "dbo.Trainers", name: "IX_Application_Id", newName: "IX_TrainerUser_Id");
            RenameColumn(table: "dbo.Trainers", name: "Application_Id", newName: "TrainerUser_Id");
            CreateIndex("dbo.Trainers", "TopicId");
            AddForeignKey("dbo.Trainers", "TopicId", "dbo.Topics", "Id", cascadeDelete: true);
        }
    }
}
