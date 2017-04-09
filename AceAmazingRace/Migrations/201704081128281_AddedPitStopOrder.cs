namespace AceAmazingRace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPitStopOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PitStopOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        PitStop_Id = c.Int(nullable: false),
                        Team_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PitStops", t => t.PitStop_Id, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.Team_Id, cascadeDelete: true)
                .Index(t => t.PitStop_Id)
                .Index(t => t.Team_Id);
            
            AddColumn("dbo.Locations", "Clue", c => c.String());
            DropColumn("dbo.Locations", "Direction");
            DropColumn("dbo.PitStops", "Order");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PitStops", "Order", c => c.Int(nullable: false));
            AddColumn("dbo.Locations", "Direction", c => c.String());
            DropForeignKey("dbo.PitStopOrders", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.PitStopOrders", "PitStop_Id", "dbo.PitStops");
            DropIndex("dbo.PitStopOrders", new[] { "Team_Id" });
            DropIndex("dbo.PitStopOrders", new[] { "PitStop_Id" });
            DropColumn("dbo.Locations", "Clue");
            DropTable("dbo.PitStopOrders");
        }
    }
}
