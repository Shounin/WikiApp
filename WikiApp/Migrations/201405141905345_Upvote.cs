namespace WikiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upvote : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Upvote",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        subtitleFileID = c.Int(nullable: false),
                        applicationUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SubtitleFile", t => t.subtitleFileID, cascadeDelete: true)
                .Index(t => t.subtitleFileID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Upvote", "subtitleFileID", "dbo.SubtitleFile");
            DropIndex("dbo.Upvote", new[] { "subtitleFileID" });
            DropTable("dbo.Upvote");
        }
    }
}
