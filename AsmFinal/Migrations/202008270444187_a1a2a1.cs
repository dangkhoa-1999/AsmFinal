namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1a2a1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrollments", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enrollments", "Name");
        }
    }
}
