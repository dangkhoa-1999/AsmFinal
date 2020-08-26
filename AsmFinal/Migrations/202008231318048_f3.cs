namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TopicDetails", "Topic_Id", "dbo.Topics");
            DropIndex("dbo.TopicDetails", new[] { "Topic_Id" });
            DropColumn("dbo.TopicDetails", "TopicId");
            RenameColumn(table: "dbo.TopicDetails", name: "Topic_Id", newName: "TopicId");
            DropPrimaryKey("dbo.Topics");
            AlterColumn("dbo.TopicDetails", "TopicId", c => c.Int(nullable: false));
            AlterColumn("dbo.Topics", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Topics", "Id");
            CreateIndex("dbo.TopicDetails", "TopicId");
            AddForeignKey("dbo.TopicDetails", "TopicId", "dbo.Topics", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TopicDetails", "TopicId", "dbo.Topics");
            DropIndex("dbo.TopicDetails", new[] { "TopicId" });
            DropPrimaryKey("dbo.Topics");
            AlterColumn("dbo.Topics", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TopicDetails", "TopicId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Topics", "Id");
            RenameColumn(table: "dbo.TopicDetails", name: "TopicId", newName: "Topic_Id");
            AddColumn("dbo.TopicDetails", "TopicId", c => c.Int(nullable: false));
            CreateIndex("dbo.TopicDetails", "Topic_Id");
            AddForeignKey("dbo.TopicDetails", "Topic_Id", "dbo.Topics", "Id");
        }
    }
}
