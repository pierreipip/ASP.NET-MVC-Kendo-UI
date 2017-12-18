namespace MyExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExerciseRecords",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ExerciseName = c.String(nullable: false, maxLength: 100),
                        ExerciseDate = c.DateTime(nullable: false),
                        DurationInMinutes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExerciseRecords");
        }
    }
}
