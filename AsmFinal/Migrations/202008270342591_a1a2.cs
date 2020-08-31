namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1a2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TopicDetails", newName: "TrainerTopics");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TrainerTopics", newName: "TopicDetails");
        }
    }
}
