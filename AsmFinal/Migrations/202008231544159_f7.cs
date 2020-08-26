namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f7 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Enrollments");
            AlterColumn("dbo.Enrollments", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Enrollments", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Enrollments");
            AlterColumn("dbo.Enrollments", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Enrollments", "Id");
        }
    }
}
