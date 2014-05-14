namespace WikiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubtitleText : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubtitleFile", "SubtitleText", c => c.String(maxLength: 8000, unicode: false));
            DropColumn("dbo.SubtitleFile", "file");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubtitleFile", "file", c => c.String(maxLength: 8000, unicode: false));
            DropColumn("dbo.SubtitleFile", "SubtitleText");
        }
    }
}
