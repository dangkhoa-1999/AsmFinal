namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TopicDetails", "TopicId", "dbo.Topics");
            DropIndex("dbo.TopicDetails", new[] { "TopicId" });
            DropPrimaryKey("dbo.Topics");
            AddColumn("dbo.TopicDetails", "Topic_Name", c => c.String(maxLength: 128));
            AddColumn("dbo.Topics", "TopicId", c => c.Int(nullable: false));
            AlterColumn("dbo.Topics", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Topics", "Name", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Topics", "Name");
            CreateIndex("dbo.TopicDetails", "Topic_Name");
            AddForeignKey("dbo.TopicDetails", "Topic_Name", "dbo.Topics", "Name");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TopicDetails", "Topic_Name", "dbo.Topics");
            DropIndex("dbo.TopicDetails", new[] { "Topic_Name" });
            DropPrimaryKey("dbo.Topics");
            AlterColumn("dbo.Topics", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Topics", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Topics", "TopicId");
            DropColumn("dbo.TopicDetails", "Topic_Name");
            AddPrimaryKey("dbo.Topics", "Id");
            CreateIndex("dbo.TopicDetails", "TopicId");
            AddForeignKey("dbo.TopicDetails", "TopicId", "dbo.Topics", "Id", cascadeDelete: true);
        }
    }
}
