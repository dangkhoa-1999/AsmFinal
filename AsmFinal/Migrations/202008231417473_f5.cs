namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TopicDetails", "TopicName", c => c.Int(nullable: false));
            DropColumn("dbo.TopicDetails", "TopicId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TopicDetails", "TopicId", c => c.Int(nullable: false));
            DropColumn("dbo.TopicDetails", "TopicName");
        }
    }
}
