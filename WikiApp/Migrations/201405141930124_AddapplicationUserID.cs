namespace WikiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddapplicationUserID : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Upvote", "applicationUserID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Upvote", "applicationUserID", c => c.Int(nullable: false));
        }
    }
}
