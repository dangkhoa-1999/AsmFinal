namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f1x1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TopicDetails", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TopicDetails", new[] { "ApplicationUser_Id" });
            DropPrimaryKey("dbo.TopicDetails");
            AddPrimaryKey("dbo.TopicDetails", new[] { "TrainerId", "TopicId" });
            DropColumn("dbo.TopicDetails", "Id");
            DropColumn("dbo.TopicDetails", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TopicDetails", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.TopicDetails", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.TopicDetails");
            AddPrimaryKey("dbo.TopicDetails", "Id");
            CreateIndex("dbo.TopicDetails", "ApplicationUser_Id");
            AddForeignKey("dbo.TopicDetails", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
