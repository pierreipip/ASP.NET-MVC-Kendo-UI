namespace MyExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExerciseRecords", "CreationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExerciseRecords", "CreationDate");
        }
    }
}
