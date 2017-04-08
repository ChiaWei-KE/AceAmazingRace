namespace AceAmazingRace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRemarkToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PitStops", "Remark", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PitStops", "Remark", c => c.Int(nullable: false));
        }
    }
}
