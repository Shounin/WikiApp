namespace WikiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Upvote", new[] { "subtitleFileID" });
            AddColumn("dbo.SubtitleComment", "SubtitleFileID", c => c.Int(nullable: false));
            CreateIndex("dbo.SubtitleComment", "SubtitleFileID");
            CreateIndex("dbo.Upvote", "SubtitleFileID");
            AddForeignKey("dbo.SubtitleComment", "SubtitleFileID", "dbo.SubtitleFile", "ID", cascadeDelete: true);
            DropColumn("dbo.SubtitleComment", "subtitleid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubtitleComment", "subtitleid", c => c.Int(nullable: false));
            DropForeignKey("dbo.SubtitleComment", "SubtitleFileID", "dbo.SubtitleFile");
            DropIndex("dbo.Upvote", new[] { "SubtitleFileID" });
            DropIndex("dbo.SubtitleComment", new[] { "SubtitleFileID" });
            DropColumn("dbo.SubtitleComment", "SubtitleFileID");
            CreateIndex("dbo.Upvote", "subtitleFileID");
        }
    }
}
