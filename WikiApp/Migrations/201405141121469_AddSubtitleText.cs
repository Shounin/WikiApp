namespace WikiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubtitleText : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SubtitleFile", "SubtitleText", c => c.String(unicode: false, storeType: "text"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubtitleFile", "SubtitleText", c => c.String(maxLength: 8000, unicode: false));
        }
    }
}
