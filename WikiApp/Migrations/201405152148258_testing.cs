namespace WikiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubtitleComment", "SubtitleFileID", c => c.Int(nullable: false));
            CreateIndex("dbo.SubtitleComment", "SubtitleFileID");
            AddForeignKey("dbo.SubtitleComment", "SubtitleFileID", "dbo.SubtitleFile", "ID", cascadeDelete: true);
            DropColumn("dbo.SubtitleComment", "subtitleid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubtitleComment", "subtitleid", c => c.Int(nullable: false));
            DropForeignKey("dbo.SubtitleComment", "SubtitleFileID", "dbo.SubtitleFile");
            DropIndex("dbo.SubtitleComment", new[] { "SubtitleFileID" });
            DropColumn("dbo.SubtitleComment", "SubtitleFileID");
        }
    }
}
