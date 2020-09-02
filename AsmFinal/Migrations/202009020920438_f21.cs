namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrainerTopics", "TrainerId", "dbo.AspNetUsers");
            DropIndex("dbo.TrainerTopics", new[] { "TrainerId" });
            DropPrimaryKey("dbo.TrainerTopics");
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.TrainerTopics", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.TrainerTopics", "TrainerId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.TrainerTopics", new[] { "TrainerId", "TopicId" });
            CreateIndex("dbo.TrainerTopics", "TrainerId");
            AddForeignKey("dbo.TrainerTopics", "TrainerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainerTopics", "TrainerId", "dbo.AspNetUsers");
            DropIndex("dbo.TrainerTopics", new[] { "TrainerId" });
            DropPrimaryKey("dbo.TrainerTopics");
            AlterColumn("dbo.TrainerTopics", "TrainerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.TrainerTopics", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AddPrimaryKey("dbo.TrainerTopics", "Id");
            CreateIndex("dbo.TrainerTopics", "TrainerId");
            AddForeignKey("dbo.TrainerTopics", "TrainerId", "dbo.AspNetUsers", "Id");
        }
    }
}
