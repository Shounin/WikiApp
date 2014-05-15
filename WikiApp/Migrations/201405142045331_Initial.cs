namespace WikiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubtitleComment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        commentDate = c.DateTime(nullable: false),
                        username = c.String(),
                        commentText = c.String(),
                        subtitleid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SubtitleFile",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        category = c.String(),
                        description = c.String(),
                        dateAdded = c.DateTime(nullable: false),
                        path = c.String(),
                        state = c.Int(nullable: false),
                        SubtitleText = c.String(unicode: false, storeType: "text"),
                        upvote = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Upvote",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        subtitleFileID = c.Int(nullable: false),
                        applicationUserID = c.String(),
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
            DropTable("dbo.SubtitleFile");
            DropTable("dbo.SubtitleComment");
        }
    }
}
