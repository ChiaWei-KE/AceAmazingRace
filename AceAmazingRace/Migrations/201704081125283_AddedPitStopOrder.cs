namespace AceAmazingRace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPitStopOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "Clue", c => c.String());
            DropColumn("dbo.Locations", "Direction");
            DropColumn("dbo.PitStops", "Order");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PitStops", "Order", c => c.Int(nullable: false));
            AddColumn("dbo.Locations", "Direction", c => c.String());
            DropColumn("dbo.Locations", "Clue");
        }
    }
}
