namespace AceAmazingRace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInstructionToDirectionTo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "Direction", c => c.String());
            DropColumn("dbo.Locations", "Instruction");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "Instruction", c => c.String());
            DropColumn("dbo.Locations", "Direction");
        }
    }
}
