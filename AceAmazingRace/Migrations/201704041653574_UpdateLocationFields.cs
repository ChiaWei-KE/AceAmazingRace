namespace AceAmazingRace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLocationFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "Longitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Locations", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Locations", "Address", c => c.String(nullable: false));
            DropColumn("dbo.Locations", "Longtitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "Longtitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Locations", "Address", c => c.String());
            AlterColumn("dbo.Locations", "Name", c => c.String());
            DropColumn("dbo.Locations", "Longitude");
        }
    }
}
