namespace AceAmazingRace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPitStop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PitStops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Order = c.Int(nullable: false),
                        Remark = c.Int(nullable: false),
                        Location_Id = c.Int(nullable: false),
                        RaceEvent_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id, cascadeDelete: false)
                .ForeignKey("dbo.RaceEvents", t => t.RaceEvent_Id, cascadeDelete: false)
                .Index(t => t.Location_Id)
                .Index(t => t.RaceEvent_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PitStops", "RaceEvent_Id", "dbo.RaceEvents");
            DropForeignKey("dbo.PitStops", "Location_Id", "dbo.Locations");
            DropIndex("dbo.PitStops", new[] { "RaceEvent_Id" });
            DropIndex("dbo.PitStops", new[] { "Location_Id" });
            DropTable("dbo.PitStops");
        }
    }
}
