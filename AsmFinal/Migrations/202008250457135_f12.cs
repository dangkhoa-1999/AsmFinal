namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", new[] { "Identity_UserId", "Identity_RoleId" }, "dbo.AspNetUserRoles");
            DropIndex("dbo.AspNetUsers", new[] { "Identity_UserId", "Identity_RoleId" });
            DropColumn("dbo.AspNetUsers", "Identity_UserId");
            DropColumn("dbo.AspNetUsers", "Identity_RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Identity_RoleId", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Identity_UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", new[] { "Identity_UserId", "Identity_RoleId" });
            AddForeignKey("dbo.AspNetUsers", new[] { "Identity_UserId", "Identity_RoleId" }, "dbo.AspNetUserRoles", new[] { "UserId", "RoleId" });
        }
    }
}
