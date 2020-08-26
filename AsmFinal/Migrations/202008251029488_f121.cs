namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f121 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TopicDetails", "trainer_Id", "dbo.Trainers");
            DropIndex("dbo.TopicDetails", new[] { "trainer_Id" });
            DropPrimaryKey("dbo.Trainers");
            AddColumn("dbo.TopicDetails", "TrainerName", c => c.String());
            AlterColumn("dbo.TopicDetails", "trainer_Id", c => c.Int());
            AlterColumn("dbo.Trainers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Trainers", "Id");
            CreateIndex("dbo.TopicDetails", "trainer_Id");
            AddForeignKey("dbo.TopicDetails", "trainer_Id", "dbo.Trainers", "Id");
            DropColumn("dbo.TopicDetails", "TrainerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TopicDetails", "TrainerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TopicDetails", "trainer_Id", "dbo.Trainers");
            DropIndex("dbo.TopicDetails", new[] { "trainer_Id" });
            DropPrimaryKey("dbo.Trainers");
            AlterColumn("dbo.Trainers", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TopicDetails", "trainer_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.TopicDetails", "TrainerName");
            AddPrimaryKey("dbo.Trainers", "Id");
            CreateIndex("dbo.TopicDetails", "trainer_Id");
            AddForeignKey("dbo.TopicDetails", "trainer_Id", "dbo.Trainers", "Id");
        }
    }
}
