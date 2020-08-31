namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TopicDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainerId = c.String(maxLength: 128),
                        TopicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.TrainerId)
                .Index(t => t.TrainerId)
                .Index(t => t.TopicId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TopicDetails", "TrainerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TopicDetails", "TopicId", "dbo.Topics");
            DropIndex("dbo.TopicDetails", new[] { "TopicId" });
            DropIndex("dbo.TopicDetails", new[] { "TrainerId" });
            DropTable("dbo.TopicDetails");
        }
    }
}
