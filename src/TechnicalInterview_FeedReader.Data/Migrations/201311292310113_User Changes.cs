namespace TechnicalInterview_FeedReader.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AlterColumn("dbo.Users", "EmailAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "EmailAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false));
        }
    }
}
