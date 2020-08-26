namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f12xx : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserViewModels", "Role", c => c.String());
            DropColumn("dbo.UserViewModels", "RoleName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserViewModels", "RoleName", c => c.String());
            DropColumn("dbo.UserViewModels", "Role");
        }
    }
}
