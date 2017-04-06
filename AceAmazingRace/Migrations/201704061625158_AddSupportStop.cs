namespace AceAmazingRace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSupportStop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupportStops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
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
            DropForeignKey("dbo.SupportStops", "RaceEvent_Id", "dbo.RaceEvents");
            DropForeignKey("dbo.SupportStops", "Location_Id", "dbo.Locations");
            DropIndex("dbo.SupportStops", new[] { "RaceEvent_Id" });
            DropIndex("dbo.SupportStops", new[] { "Location_Id" });
            DropTable("dbo.SupportStops");
        }
    }
}
