namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fax1a : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trainers", "TrainerId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainers", "TrainerId", c => c.Int(nullable: false));
        }
    }
}
