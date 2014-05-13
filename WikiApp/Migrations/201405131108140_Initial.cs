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
                        upvote = c.Int(nullable: false),
                        path = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubtitleFile");
            DropTable("dbo.SubtitleComment");
        }
    }
}
