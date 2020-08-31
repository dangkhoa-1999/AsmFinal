namespace AsmFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1a2a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TraineeEnrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TraineeId = c.String(maxLength: 128),
                        EnrollmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enrollments", t => t.EnrollmentId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.TraineeId)
                .Index(t => t.TraineeId)
                .Index(t => t.EnrollmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TraineeEnrollments", "TraineeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TraineeEnrollments", "EnrollmentId", "dbo.Enrollments");
            DropIndex("dbo.TraineeEnrollments", new[] { "EnrollmentId" });
            DropIndex("dbo.TraineeEnrollments", new[] { "TraineeId" });
            DropTable("dbo.TraineeEnrollments");
        }
    }
}
