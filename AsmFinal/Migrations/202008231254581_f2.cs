namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollments", "Id", "dbo.Trainees");
            DropIndex("dbo.Enrollments", new[] { "Id" });
            DropPrimaryKey("dbo.Enrollments");
            AddColumn("dbo.Enrollments", "Trainee_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Enrollments", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Enrollments", "Id");
            CreateIndex("dbo.Enrollments", "Trainee_Id");
            AddForeignKey("dbo.Enrollments", "Trainee_Id", "dbo.Trainees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "Trainee_Id", "dbo.Trainees");
            DropIndex("dbo.Enrollments", new[] { "Trainee_Id" });
            DropPrimaryKey("dbo.Enrollments");
            AlterColumn("dbo.Enrollments", "Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Enrollments", "Trainee_Id");
            AddPrimaryKey("dbo.Enrollments", new[] { "CourseId", "TraineeId" });
            CreateIndex("dbo.Enrollments", "Id");
            AddForeignKey("dbo.Enrollments", "Id", "dbo.Trainees", "Id");
        }
    }
}
