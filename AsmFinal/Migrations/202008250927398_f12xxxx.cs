namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f12xxxx : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainers", "TopicId", c => c.Int(nullable: false));
            CreateIndex("dbo.Trainers", "TopicId");
            AddForeignKey("dbo.Trainers", "TopicId", "dbo.Topics", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers", "TopicId", "dbo.Topics");
            DropIndex("dbo.Trainers", new[] { "TopicId" });
            DropColumn("dbo.Trainers", "TopicId");
        }
    }
}
