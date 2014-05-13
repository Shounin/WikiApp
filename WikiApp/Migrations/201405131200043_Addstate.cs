namespace WikiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addstate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubtitleFile", "state", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubtitleFile", "state");
        }
    }
}
