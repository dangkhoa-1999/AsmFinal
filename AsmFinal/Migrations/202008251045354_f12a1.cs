namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f12a1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TopicDetails", "trainer_Id", "dbo.Trainers");
            DropIndex("dbo.TopicDetails", new[] { "trainer_Id" });
            AddColumn("dbo.TopicDetails", "TrainerId", c => c.Int(nullable: false));
            AddColumn("dbo.TopicDetails", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.TopicDetails", "ApplicationUser_Id");
            AddForeignKey("dbo.TopicDetails", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.TopicDetails", "trainer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TopicDetails", "trainer_Id", c => c.Int());
            DropForeignKey("dbo.TopicDetails", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TopicDetails", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.TopicDetails", "ApplicationUser_Id");
            DropColumn("dbo.TopicDetails", "TrainerId");
            CreateIndex("dbo.TopicDetails", "trainer_Id");
            AddForeignKey("dbo.TopicDetails", "trainer_Id", "dbo.Trainers", "Id");
        }
    }
}
