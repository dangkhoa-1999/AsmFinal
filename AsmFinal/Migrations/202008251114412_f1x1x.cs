namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f1x1x : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TopicDetails", "TopicId", "dbo.Topics");
            DropIndex("dbo.TopicDetails", new[] { "TopicId" });
            DropTable("dbo.TopicDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TopicDetails",
                c => new
                    {
                        TrainerId = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                        TopicDateStarted = c.DateTime(nullable: false),
                        TopicDateExpired = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrainerId, t.TopicId });
            
            CreateIndex("dbo.TopicDetails", "TopicId");
            AddForeignKey("dbo.TopicDetails", "TopicId", "dbo.Topics", "Id", cascadeDelete: true);
        }
    }
}
