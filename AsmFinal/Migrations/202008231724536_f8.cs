namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trainees", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Trainees", new[] { "User_Id" });
            DropColumn("dbo.Trainees", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainees", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Trainees", "User_Id");
            AddForeignKey("dbo.Trainees", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
