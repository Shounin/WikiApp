namespace WikiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubtitleFile", "file", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubtitleFile", "file");
        }
    }
}
