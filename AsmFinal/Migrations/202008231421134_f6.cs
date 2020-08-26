namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TopicDetails", "Topic_Name", "dbo.Topics");
            DropIndex("dbo.TopicDetails", new[] { "Topic_Name" });
            RenameColumn(table: "dbo.TopicDetails", name: "Topic_Name", newName: "TopicId");
            DropPrimaryKey("dbo.Topics");
            AlterColumn("dbo.TopicDetails", "TopicId", c => c.Int(nullable: false));
            AlterColumn("dbo.Topics", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Topics", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Topics", "Id");
            CreateIndex("dbo.TopicDetails", "TopicId");
            AddForeignKey("dbo.TopicDetails", "TopicId", "dbo.Topics", "Id", cascadeDelete: true);
            DropColumn("dbo.TopicDetails", "TopicName");
            DropColumn("dbo.Topics", "TopicId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Topics", "TopicId", c => c.Int(nullable: false));
            AddColumn("dbo.TopicDetails", "TopicName", c => c.Int(nullable: false));
            DropForeignKey("dbo.TopicDetails", "TopicId", "dbo.Topics");
            DropIndex("dbo.TopicDetails", new[] { "TopicId" });
            DropPrimaryKey("dbo.Topics");
            AlterColumn("dbo.Topics", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Topics", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TopicDetails", "TopicId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Topics", "Name");
            RenameColumn(table: "dbo.TopicDetails", name: "TopicId", newName: "Topic_Name");
            CreateIndex("dbo.TopicDetails", "Topic_Name");
            AddForeignKey("dbo.TopicDetails", "Topic_Name", "dbo.Topics", "Name");
        }
    }
}
