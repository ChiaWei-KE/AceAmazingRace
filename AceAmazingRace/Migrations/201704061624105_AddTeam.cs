namespace AceAmazingRace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Profile = c.String(nullable: false),
                        Photo = c.Binary(),
                        RaceEvent_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RaceEvents", t => t.RaceEvent_Id, cascadeDelete: false)
                .Index(t => t.RaceEvent_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "RaceEvent_Id", "dbo.RaceEvents");
            DropIndex("dbo.Teams", new[] { "RaceEvent_Id" });
            DropTable("dbo.Teams");
        }
    }
}
