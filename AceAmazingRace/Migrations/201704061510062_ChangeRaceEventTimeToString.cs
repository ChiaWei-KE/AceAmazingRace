namespace AceAmazingRace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRaceEventTimeToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RaceEvents", "Time", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RaceEvents", "Time", c => c.Int(nullable: false));
        }
    }
}
