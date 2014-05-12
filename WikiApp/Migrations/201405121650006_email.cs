namespace WikiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class email : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "email", c => c.String());
            AddColumn("dbo.AspNetUsers", "fullName", c => c.String());
            AddColumn("dbo.AspNetUsers", "birthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "birthDate");
            DropColumn("dbo.AspNetUsers", "fullName");
            DropColumn("dbo.AspNetUsers", "email");
        }
    }
}
