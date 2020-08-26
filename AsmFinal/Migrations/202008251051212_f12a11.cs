namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f12a11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TopicDetails", "TrainerName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TopicDetails", "TrainerName", c => c.String());
        }
    }
}
